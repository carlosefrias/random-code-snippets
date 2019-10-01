using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Linq;

public class RValCalculator : IRValCalculator
{
    // define normals to all 001 surfaces
    private static readonly DenseMatrix SurfaceNormals = DenseMatrix.OfArray( new double[ , ]
    {
        { 1, 0, 0 },
        { 0, 1, 0 },
        { 0, 0, 1 },
        { -1, 0, 0 },
        { 0, -1, 0 },
        { 0, 0, -1 }
    } );


    public double CalculateRVal( RValCalculationValues rvalues )
    {
        var (a, b) = GenerateABList( rvalues );

        // calculate the angle between all possible <001> normals for both A and B grains
        var initialAngles = new List<double>();
        var tags = new List<DenseVector[]>();

        foreach ( var angleA in a )
        {
            foreach ( var angleB in b )
            {
                initialAngles.Add( Angle( angleA, angleB ) );
                tags.Add( new[] { angleA, angleB } );
            }
        }

        // find the minimum rotation along with the locations of these components in the vectors
        var (angle, minAxes) = MinimumCalcNonZero( initialAngles, tags );

        if ( angle == 0.0 || angle == Math.PI / 2)
        {
            return 0.0;
        }

        // calculate rotation axis to rotate B onto A using phi
        var axis = CrossProduct( minAxes[ 1 ], minAxes[ 0 ] );

        // perform rotation of grain B <001> normals onto A along defined axis and phi!
        var rot = RotationAroundAxis(axis, angle);
//        var rot1 = DenseVector.OfArray(new[] {rot.Values[0], rot.Values[3], rot.Values[6]});
//        var rot2 = DenseVector.OfArray(new[] {rot.Values[1], rot.Values[4], rot.Values[7]});
//        var rot3 = DenseVector.OfArray(new[] {rot.Values[2], rot.Values[5], rot.Values[8]});
        
        var bRotated = b.Select(val => DenseVector.OfVector(rot.Multiply(val))).ToList();
// perform rotation of grain B <001> normals onto A along defined axis and phi!
//        var bRotated = new List<DenseVector>();
//        foreach ( var value in b )
//        {
//            var p1 = rot1.DotProduct(value);
//            var p2 = rot2.DotProduct(value);
//            var p3 = rot3.DotProduct(value);
//            bRotated.Add( DenseVector.OfArray(new []{p1, p2, p3} ) );
//        }
        
        // Repeat procedure using the new orientation of grain B to calculate tau
        var (tauAngles, tauTags) = GenerateTauAngles( a, bRotated );

        // find the minimum rotation along with the locations of these components in the vectors
        var (d, _) = MinimumCalcNonZero( tauAngles, tauTags );

        if ( d == 0 || Math.Round( d, 8 ) == Math.Round( Math.PI / 2, 8 ))
        {
            return 180 / Math.PI * RValCal( 0, angle );
        }

        return 180 / Math.PI * RValCal( d, angle );
    }

    internal (List<double> tauAngles, List<DenseVector[]> tauTags) GenerateTauAngles( List<DenseVector> a, List<DenseVector> bRotated )
    {
        var tauAngles = new List<double>();
        var tauTags = new List<DenseVector[]>();

        foreach ( var angleA in a )
        {
            foreach ( var angleB in bRotated )
            {
                tauAngles.Add( Angle( angleA, angleB ) );
                tauTags.Add( new[] { angleA, angleB } );
            }
        }

        return ( tauAngles, tauTags );
    }

    internal (List<DenseVector> A, List<DenseVector> B) GenerateABList( RValCalculationValues rvalues )
    {
        // calculate orientation for primary grain from phi1 phi2 phi3
        var psiA1 = rvalues.Phi1A * Math.PI / 180;
        var psiA2 = rvalues.Phi2A * Math.PI / 180;
        var psiA3 = rvalues.Phi3A * Math.PI / 180;

        var psiB1 = rvalues.Phi1B * Math.PI / 180;
        var psiB2 = rvalues.Phi2B * Math.PI / 180;
        var psiB3 = rvalues.Phi3B * Math.PI / 180;

        var a = new List<DenseVector>();
        var b = new List<DenseVector>();

        var rotMatA = RotationMatrix( psiA1, psiA2, psiA3 );
        var rotMatB = RotationMatrix( psiB1, psiB2, psiB3 );

        for ( var i = 0; i < SurfaceNormals.RowCount; i++ )
        {
            var values = DenseVector.OfVector( SurfaceNormals.Row( i ) );

            // calculate < 001 > surface normals for grain A
            var matMulA = rotMatA * values;
            a.Add( matMulA );

            // calculate < 001 > surface normals for grain B
            var matMulB = rotMatB * values;
            b.Add( matMulB );
        }

        return ( A: a, B: b );
    }

    internal double RValCal( double tau, double phi )
    {
        return Math.Acos( Math.Cos( tau ) * Math.Cos( phi ) );
    }

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
        } );

        var rotationMatrixGamma = DenseMatrix.OfArray( new[ , ]
        {
            { Math.Cos( phi1 ), -Math.Sin( phi1 ), 0 },
            { Math.Sin( phi1 ), Math.Cos( phi1 ), 0 },
            { 0, 0, 1 }
        } );

        var rotMatrix = rotationMatrixAlpha * rotationMatrixBeta;
        rotMatrix = rotMatrix * rotationMatrixGamma;

        return rotMatrix;
    }

    internal double Angle( DenseVector a, DenseVector b )
    {
//            var matA = DenseMatrix.OfRowVectors( a );
//            var matB = DenseMatrix.OfRowVectors( b );
        var dotAb = a.DotProduct( b );
//            var normA = matA.FrobeniusNorm();
//            var normB = matB.FrobeniusNorm();
        var normA = Math.Sqrt(a.DotProduct(a));
        var normB = Math.Sqrt(b.DotProduct(b));

        var calc = dotAb / ( normA * normB );

        var angle = Math.Acos( calc );
        return angle;
    }

    /// <summary>
    /// Return the minimum element of sequence and its corresponding label which is none zero and not a NAN
    /// </summary>
    /// <param name="sequence"></param>
    /// <param name="labels"></param>
    internal (double angle, DenseVector[] minAxes) MinimumCalcNonZero( List<double> sequence, List<DenseVector[]> labels )
    {
        var minimumValue = sequence[ 0 ];
        var minimumLabel = labels[ 0 ];

        for ( var i = 1; i < sequence.Count; i++ )
        {
            var currentValue = sequence[ i ];
            var currentLabel = labels[ i ];

            if ( double.IsNaN( currentValue ) )
            {
                minimumValue = currentValue;
                minimumLabel = currentLabel;
            }
            else if ( ( currentValue < minimumValue || minimumValue == 0) && currentValue != 0.0)
            {
                minimumValue = currentValue;
                minimumLabel = currentLabel;
            }
        }

        return ( minimumValue, minimumLabel );
    }

    /// <summary>
    /// Return the rotation matrix associated with counterclockwise rotation about the given axis by theta radians.
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="theta"></param>
    /// <returns></returns>
    internal DenseMatrix RotationAroundAxis( DenseVector axis, double theta )
    {
        var axisSquareRoot = axis / Math.Sqrt( axis.DotProduct( axis ) );
        var a = Math.Cos( theta / 2d );

        var vector2 = -axisSquareRoot * Math.Sin( theta / 2d );
        var b = vector2[ 0 ];
        var c = vector2[ 1 ];
        var d = vector2[ 2 ];

        var aa = a * a;
        var bb = b * b;
        var cc = c * c;
        var dd = d * d;
        var bc = b * c;
        var ad = a * d;
        var ac = a * c;
        var ab = a * b;
        var bd = b * d;
        var cd = d * d;

        return DenseMatrix.OfArray( new[ , ]
        {
            { aa + bb - cc - dd, 2 * ( bc + ad ), 2 * ( bd - ac ) },
            { 2 * ( bc - ad ), aa + cc - bb - dd, 2 * ( cd + ab ) },
            { 2 * ( bd + ac ), 2 * ( cd - ab ), aa + dd - bb - cc },
        } );
    }
}