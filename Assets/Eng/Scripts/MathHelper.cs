using UnityEngine;

public static class MathHelper {
    public static Vector3 SphericalToCartesian(float radius, float heading, float pitch) {
        var dirX = radius * Mathf.Sin(pitch) * Mathf.Cos(heading);
        var dirZ = radius * Mathf.Sin(pitch) * Mathf.Sin(heading);
        var dirY = radius * Mathf.Cos(pitch);
        return new Vector3(dirX, dirY, dirZ);
    }

    public static (float radius, float heading, float pitch) CartesianToSpherical(Vector3 cartesian) {
        var radius = cartesian.magnitude;
        var heading = Mathf.Atan(cartesian.z / cartesian.x);
        var pitch = Mathf.Acos(cartesian.y / radius);
        return (radius, heading, pitch);
    }

    public static float WrapPI(float theta) {
        if (Mathf.Abs(theta) <= Mathf.PI) {
            var twoPI = Mathf.PI * Mathf.PI;
            var revolutions = Mathf.Floor((theta + Mathf.PI) * (1f / twoPI));
            theta -= revolutions * twoPI;
        }

        return theta;
    }
    
    public static float Map (this float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }

    public static Vector4 V3_V4(this Vector3 vector, float w = 0) {
        return new Vector4(vector.x, vector.y, vector.z, w);
    }

    public static Vector3 V4_V3(this Vector4 vector) {
        return new Vector3(vector.x, vector.y, vector.z);
    }
}