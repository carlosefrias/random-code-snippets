using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

public class RValCalculator : IRValCalculator
{
    private const double Tolerance = 1.0E-10;
    // define normals to all 001 surfaces
    private static readonly List<DenseVector> SurfaceNormals = new List<DenseVector>
    {
        DenseVector.OfArray(new[] { 1.0, 0.0, 0.0 }),
        DenseVector.OfArray(new[] { 0.0, 1.0, 0.0 }),
        DenseVector.OfArray(new[] { 1.0, 0.0, 0.0 }),
        DenseVector.OfArray(new[] { -1.0, 0.0, 0.0 }),
        DenseVector.OfArray(new[] { 0.0, -1.0, 0.0 }),
        DenseVector.OfArray(new[] { 0.0, 0.0, -1.0 }),
    };

    /// <summary>
    /// Calculates the RVal between two crystal orientations
    /// </summary>
    /// <param name="rvalues"></param>
    /// <returns></returns>
    public double CalculateRVal( RValCalculationValues rvalues )
    {
        // calculate orientation for primary grain from phi1 phi2 phi3
        var psiA1 = rvalues.Phi1A.ToRadians();
        var psiA2 = rvalues.Phi2A.ToRadians();
        var psiA3 = rvalues.Phi3A.ToRadians();

        var psiB1 = rvalues.Phi1B.ToRadians();
        var psiB2 = rvalues.Phi2B.ToRadians();
        var psiB3 = rvalues.Phi3B.ToRadians();
        
        var rotMatA = RotationMatrix( psiA1, psiA2, psiA3 );
        var rotMatB = RotationMatrix( psiB1, psiB2, psiB3 );
        
        var a = SurfaceNormals.Select(sn => rotMatA * sn).ToList();
        var b = SurfaceNormals.Select(sn => rotMatB * sn).ToList();
        
        // calculate the angle between all possible <001> normals for both A and B grains
        // and find the minimum rotation along with the locations of these components in the vectors
        var angleTagPair = (from angleA in a
            from angleB in b
            let angleBetweenThem = Angle(angleA, angleB)
            where !double.IsNaN(angleBetweenThem) && Math.Abs(angleBetweenThem) > Tolerance
            select new
            {
                initialAngle = angleBetweenThem,
                tag = new[] {angleA, angleB}
            })
            .OrderBy(val => val.initialAngle)
            .FirstOrDefault();
        if (angleTagPair == null)
            return 0.0;
        var angle = angleTagPair.initialAngle;
        var minAxes = angleTagPair.tag;
        
        if (Math.Abs(angle) < Tolerance || Math.Abs(angle - Math.PI / 2) < Tolerance)
            return 0.0;

        // calculate rotation axis to rotate B onto A using phi
        var axis = CrossProduct( minAxes[ 1 ], minAxes[ 0 ] );

        // perform rotation of grain B <001> normals onto A along defined axis and phi!
        var rot = RotationAroundAxis(axis, angle);
        var bRotated = b.Select(value => DenseVector.OfVector(rot * value));
        
        // Repeat procedure using the new orientation of grain B to calculate tau
        // find the minimum rotation along with the locations of these components in the vectors
        var tau = (from angleA in a
                    from angleB in bRotated
                    let angleBetweenThem = Angle(angleA, angleB)
                    where !double.IsNaN(angleBetweenThem) && Math.Abs(angleBetweenThem) > Tolerance
                    select angleBetweenThem)
                .OrderBy(val => val)
                .FirstOrDefault();
        
        if ( Math.Abs(tau) < Tolerance || Math.Abs(Math.Round(tau, 8) - Math.Round(Math.PI / 2)) < Tolerance )
        {
            return RValCal(0, angle).ToDegrees();
        }

        return RValCal(tau, angle).ToDegrees();
    }

    /// <summary>
    /// Performs the final RVal calculation
    /// knowing the value of tau and phi
    /// </summary>
    /// <param name="tau"></param>
    /// <param name="phi"></param>
    /// <returns></returns>
    internal double RValCal( double tau, double phi )
    {
        return Math.Acos( Math.Cos( tau ) * Math.Cos( phi ) );
    }

    /// <summary>
    /// Calculates the cross product (or external product) between two vectors
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    internal DenseVector CrossProduct( DenseVector a, DenseVector b )
    {
        double[] crossProduct =
        {
            a[ 1 ] * b[ 2 ] - a[ 2 ] * b[ 1 ],
            a[ 2 ] * b[ 0 ] - a[ 0 ] * b[ 2 ],
            a[ 0 ] * b[ 1 ] - a[ 1 ] * b[ 0 ]
        };
        return DenseVector.OfArray(crossProduct);
    }

    /// <summary>
    /// Apply rotation matrices to orientate crystal relative to incident X-ray beam
    /// </summary>
    /// <param name="phi1"></param>
    /// <param name="phi2"></param>
    /// <param name="phi3"></param>
    /// <returns></returns>
    private DenseMatrix RotationMatrix( double phi1, double phi2, double phi3 )
    {
        var rotationMatrixAlpha = DenseMatrix.OfArray( new[ , ]
        {
            { 1, 0, 0 },
            { 0, Math.Cos( phi3 ), Math.Sin( phi3 ) },
            { 0, -Math.Sin( phi3 ), Math.Cos( phi3 ) }
        } );
        var rotationMatrixBeta = DenseMatrix.OfArray( new[ , ]
        {
            { Math.Cos( phi2 ), 0, Math.Sin( phi2 ) },
            { 0, 1, 0 },
            { -Math.Sin( phi2 ), 0, Math.Cos( phi2 ) }
        });
        var rotationMatrixGamma = DenseMatrix.OfArray(new[,]
        {
            {Math.Cos(phi1), -Math.Sin(phi1), 0},
            {Math.Sin(phi1), Math.Cos(phi1), 0},
            {0, 0, 1}
        });
        return rotationMatrixAlpha * rotationMatrixBeta * rotationMatrixGamma;
    }
    
    /// <summary>
    /// Calculates the angle (in radians) between two vectors
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private double Angle(DenseVector a, DenseVector b)
    {
        return Math.Acos(a.DotProduct(b) / (a.L2Norm() * b.L2Norm()));
    }

    /// <summary>
    /// Return the rotation matrix associated with counterclockwise rotation about the given axis by theta radians.
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="theta"></param>
    /// <returns></returns>
    private DenseMatrix RotationAroundAxis( DenseVector axis, double theta )
    {
        var axisSquareRoot = axis / axis.L2Norm();
        var a = Math.Cos( theta / 2d );

        var vector2 = -axisSquareRoot * Math.Sin( theta / 2d );
        var b = vector2[ 0 ];
        var c = vector2[ 1 ];
        var d = vector2[ 2 ];

        double aa = a * a,
               bb = b * b,
               cc = c * c,
               dd = d * d,
               bc = b * c,
               ad = a * d,
               ac = a * c,
               ab = a * b,
               bd = b * d,
               cd = c * d;

        return DenseMatrix.OfArray( new[ , ]
        {
            { aa + bb - cc - dd, 2 * ( bc + ad ), 2 * ( bd - ac ) },
            { 2 * ( bc - ad ), aa + cc - bb - dd, 2 * ( cd + ab ) },
            { 2 * ( bd + ac ), 2 * ( cd - ab ), aa + dd - bb - cc },
        } );
    }
}
public static class AngleConverter
{
    /// <summary>
    /// Extension method that allows to convert from degrees to radians
    /// </summary>
    /// <param name="angleInDegrees"></param>
    /// <returns></returns>
    public static double ToRadians(this double angleInDegrees)
    {
        // Angle in degrees
        return angleInDegrees * Math.PI / 180.0;
    }

    public static double ToDegrees(this double angleInRadians)
    {
        return angleInRadians * 180.0 / Math.PI;
    }
}