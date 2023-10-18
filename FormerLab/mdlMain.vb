Imports System.Runtime.InteropServices

Module VbDemo

    ' Call our example functions, which set up some kind of sketch, solve
    ' it, and then print the result. 
    Sub testSlvs()
        'Console.WriteLine("EXAMPLE IN 3d (by objects):")
        Example3dWithObjects()
        'Console.WriteLine("")

        'Console.WriteLine("EXAMPLE IN 2d (by objects):")
        Example2dWithObjects()
        'Console.WriteLine("")

        'Console.WriteLine("EXAMPLE IN 3d (by handles):")
        Example3dWithHandles()
        'Console.WriteLine("")

        'Console.WriteLine("EXAMPLE IN 2d (by handles):")
        Example2dWithHandles()
        'Console.WriteLine("")
    End Sub


    '''''''''''''''''''''''''''''''
    ' This is the simplest way to use the library. A set of wrapper
    ' classes allow us to represent entities (e.g., lines and points)
    ' as .net objects. So we create an Slvs object, which will contain
    ' the entire sketch, with all the entities and constraints.
    ' 
    ' We then create entity objects (for example, points and lines)
    ' associated with that sketch, indicating the initial positions of
    ' those entities and any hierarchical relationships among them (e.g.,
    ' defining a line entity in terms of endpoint entities). We also add
    ' constraints associated with those entities.
    ' 
    ' Finally, we solve, and print the new positions of the entities. If the
    ' solution succeeded, then the entities will satisfy the constraints. If
    ' not, then the solver will suggest problematic constraints that, if
    ' removed, would render the sketch solvable.

    Sub Example3dWithObjects()
        Dim g As UInteger
        Dim slv As New Slvs

        ' This will contain a single group, which will arbitrarily number 1.
        g = 1

        Dim p1, p2 As Slvs.Point3d
        ' A point, initially at (x y z) = (10 10 10)
        p1 = slv.NewPoint3d(g, 10.0, 10.0, 10.0)
        ' and a second point at (20 20 20)
        p2 = slv.NewPoint3d(g, 20.0, 20.0, 20.0)

        Dim ln As Slvs.LineSegment
        ' and a line segment connecting them.
        ln = slv.NewLineSegment(g, slv.FreeIn3d(), p1, p2)

        ' The distance between the points should be 30.0 units.
        slv.AddConstraint(1, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
                              slv.FreeIn3d(), 30.0, p1, p2, Nothing, Nothing)

        ' Let's tell the solver to keep the second point as close to constant
        ' as possible, instead moving the first point.
        slv.Solve(g, p2, True)

        If (slv.GetResult() = Slvs.SLVS_RESULT_OKAY) Then
            ' We call the GetX(), GetY(), and GetZ() functions to see
            ' where the solver moved our points to.
            'Console.WriteLine(String.Format( _
            ' "okay; now at ({0:F3}, {1:F3}, {2:F3})", _
            'p1.GetX(), p1.GetY(), p1.GetZ()))
            'Console.WriteLine(String.Format( _
            '"             ({0:F3}, {1:F3}, {2:F3})", _
            'p2.GetX(), p2.GetY(), p2.GetZ()))
            'Console.WriteLine(slv.GetDof().ToString() + " DOF")
        Else
            'Console.WriteLine("solve failed")
        End If
    End Sub

    Sub Example2dWithObjects()
        Dim g As UInteger
        Dim slv As New Slvs

        g = 1

        ' First, we create our workplane. Its origin corresponds to the origin
        ' of our base frame (x y z) = (0 0 0)
        Dim origin As Slvs.Point3d
        origin = slv.NewPoint3d(g, 0.0, 0.0, 0.0)
        ' and it is parallel to the xy plane, so it has basis vectors (1 0 0)
        ' and (0 1 0).
        Dim normal As Slvs.Normal3d
        normal = slv.NewNormal3d(g, 1.0, 0.0, 0.0, _
                                    0.0, 1.0, 0.0)

        Dim wrkpl As Slvs.Workplane
        wrkpl = slv.NewWorkplane(g, origin, normal)

        ' Now create a second group. We'll solve group 2, while leaving group 1
        ' constant; so the workplane that we've created will be locked down,
        ' and the solver can't move it.
        g = 2
        ' These points are represented by their coordinates (u v) within the
        ' workplane, so they need only two parameters each.
        Dim pl1, pl2 As Slvs.Point2d
        pl1 = slv.NewPoint2d(g, wrkpl, 10.0, 20.0)
        pl2 = slv.NewPoint2d(g, wrkpl, 20.0, 10.0)

        ' And we create a line segment with those endpoints.
        Dim ln As Slvs.LineSegment
        ln = slv.NewLineSegment(g, wrkpl, pl1, pl2)

        ' Now three more points.
        Dim pc, ps, pf As Slvs.Point2d
        pc = slv.NewPoint2d(g, wrkpl, 100.0, 120.0)
        ps = slv.NewPoint2d(g, wrkpl, 120.0, 110.0)
        pf = slv.NewPoint2d(g, wrkpl, 115.0, 115.0)

        ' And arc, centered at point pc, starting at point ps, ending at
        ' point pf.
        Dim arc As Slvs.ArcOfCircle
        arc = slv.NewArcOfCircle(g, wrkpl, normal, pc, ps, pf)

        ' Now one more point, and a distance
        Dim pcc As Slvs.Point2d
        pcc = slv.NewPoint2d(g, wrkpl, 200.0, 200.0)
        Dim r As Slvs.Distance
        r = slv.NewDistance(g, wrkpl, 30.0)

        ' And a complete circle, centered at point pcc with radius equal to
        ' distance r. The normal is the same as for our workplane.
        Dim circle As Slvs.Circle
        circle = slv.NewCircle(g, wrkpl, pcc, normal, r)

        ' The length of our line segment is 30.0 units.
        slv.AddConstraint(1, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
            wrkpl, 30.0, pl1, pl2, Nothing, Nothing)

        ' And the distance from our line segment to the origin is 10.0 units.
        slv.AddConstraint(2, g, Slvs.SLVS_C_PT_LINE_DISTANCE, _
            wrkpl, 10.0, origin, Nothing, ln, Nothing)

        ' And the line segment is vertical.
        slv.AddConstraint(3, g, Slvs.SLVS_C_VERTICAL, _
            wrkpl, 0.0, Nothing, Nothing, ln, Nothing)

        ' And the distance from one endpoint to the origin is 15.0 units.
        slv.AddConstraint(4, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
            wrkpl, 15.0, pl1, origin, Nothing, Nothing)

        ' And same for the other endpoint; so if you add this constraint then
        ' the sketch is overconstrained and will signal an error.
        'slv.AddConstraint(5, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
        '    wrkpl, 18.0, pl2, origin, Nothing, Nothing)

        ' The arc and the circle have equal radius.
        slv.AddConstraint(6, g, Slvs.SLVS_C_EQUAL_RADIUS, _
            wrkpl, 0.0, Nothing, Nothing, arc, circle)

        ' The arc has radius 17.0 units.
        slv.AddConstraint(7, g, Slvs.SLVS_C_DIAMETER, _
            wrkpl, 2 * 17.0, Nothing, Nothing, arc, Nothing)

        ' If the solver fails, then ask it to report which constraints caused
        ' the problem.
        slv.Solve(g, True)

        If (slv.GetResult() = Slvs.SLVS_RESULT_OKAY) Then
            'Console.WriteLine("solved okay")
            ' We call the GetU(), GetV(), and GetDistance() functions to
            ' see where the solver moved our points and distances to.
            'Console.WriteLine(String.Format( _
            '"line from ({0:F3} {1:F3}) to ({2:F3} {3:F3})", _
            'pl1.GetU(), pl1.GetV(), _
            'pl2.GetU(), pl2.GetV()))
            'Console.WriteLine(String.Format( _
            '"arc center ({0:F3} {1:F3}) start ({2:F3} {3:F3}) " + _
            '    "finish ({4:F3} {5:F3})", _
            'pc.GetU(), pc.GetV(), _
            'ps.GetU(), ps.GetV(), _
            'pf.GetU(), pf.GetV()))
            'Console.WriteLine(String.Format( _
            '"circle center ({0:F3} {1:F3}) radius {2:F3}", _
            'pcc.GetU(), pcc.GetV(), _
            'r.GetDistance()))

            'Console.WriteLine(slv.GetDof().ToString() + " DOF")
        Else
            'Console.Write("solve failed; problematic constraints are:")
            Dim t As UInteger
            For Each t In slv.GetFaileds()
                'Console.Write(" " + t.ToString())
            Next
            'Console.WriteLine("")
            If (slv.GetResult() = Slvs.SLVS_RESULT_INCONSISTENT) Then
                'Console.WriteLine("system inconsistent")
            Else
                'Console.WriteLine("system nonconvergent")
            End If
        End If

    End Sub


    '''''''''''''''''''''''''''''''
    ' This is a lower-level way to use the library. Internally, the library
    ' represents parameters, entities, and constraints by integer handles.
    ' Here, those handles are assigned manually, and not by the wrapper
    ' classes.

    Sub Example3dWithHandles()
        Dim g As UInteger
        Dim slv As New Slvs

        ' This will contain a single group, which will arbitrarily number 1.
        g = 1

        ' A point, initially at (x y z) = (10 10 10)
        slv.AddParam(1, g, 10.0)
        slv.AddParam(2, g, 10.0)
        slv.AddParam(3, g, 10.0)
        slv.AddPoint3d(101, g, 1, 2, 3)

        ' and a second point at (20 20 20)
        slv.AddParam(4, g, 20.0)
        slv.AddParam(5, g, 20.0)
        slv.AddParam(6, g, 20.0)
        slv.AddPoint3d(102, g, 4, 5, 6)

        ' and a line segment connecting them.
        slv.AddLineSegment(200, g, Slvs.SLVS_FREE_IN_3D, 101, 102)

        ' The distance between the points should be 30.0 units.
        slv.AddConstraint(1, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
            Slvs.SLVS_FREE_IN_3D, 30.0, 101, 102, 0, 0)

        ' Let's tell the solver to keep the second point as close to constant
        ' as possible, instead moving the first point. That's parameters
        ' 4, 5, and 6.
        slv.Solve(g, 4, 5, 6, 0, True)

        If (slv.GetResult() = Slvs.SLVS_RESULT_OKAY) Then
            ' Note that we are referring to the parameters by their handles,
            ' and not by their index in the list. This is a difference from
            ' the C example.
            'Console.WriteLine(String.Format( _
            '"okay; now at ({0:F3}, {1:F3}, {2:F3})", _
            'slv.GetParamByHandle(1), slv.GetParamByHandle(2), _
            'slv.GetParamByHandle(3)))
            'Console.WriteLine(String.Format( _
            '"             ({0:F3}, {1:F3}, {2:F3})", _
            'slv.GetParamByHandle(4), slv.GetParamByHandle(5), _
            'slv.GetParamByHandle(6)))
            'Console.WriteLine(slv.GetDof().ToString() + " DOF")
        Else
            'Console.WriteLine("solve failed")
        End If
    End Sub


    Sub Example2dWithHandles()
        Dim g As UInteger
        Dim qw, qx, qy, qz As Double

        Dim slv As New Slvs

        g = 1

        ' First, we create our workplane. Its origin corresponds to the origin
        ' of our base frame (x y z) = (0 0 0)
        slv.AddParam(1, g, 0.0)
        slv.AddParam(2, g, 0.0)
        slv.AddParam(3, g, 0.0)
        slv.AddPoint3d(101, g, 1, 2, 3)
        ' and it is parallel to the xy plane, so it has basis vectors (1 0 0)
        ' and (0 1 0).
        slv.MakeQuaternion(1, 0, 0, _
                           0, 1, 0, qw, qx, qy, qz)
        slv.AddParam(4, g, qw)
        slv.AddParam(5, g, qx)
        slv.AddParam(6, g, qy)
        slv.AddParam(7, g, qz)
        slv.AddNormal3d(102, g, 4, 5, 6, 7)

        slv.AddWorkplane(200, g, 101, 102)

        ' Now create a second group. We'll solve group 2, while leaving group 1
        ' constant; so the workplane that we've created will be locked down,
        ' and the solver can't move it.
        g = 2
        ' These points are represented by their coordinates (u v) within the
        ' workplane, so they need only two parameters each.
        slv.AddParam(11, g, 10.0)
        slv.AddParam(12, g, 20.0)
        slv.AddPoint2d(301, g, 200, 11, 12)

        slv.AddParam(13, g, 20.0)
        slv.AddParam(14, g, 10.0)
        slv.AddPoint2d(302, g, 200, 13, 14)

        ' And we create a line segment with those endpoints.
        slv.AddLineSegment(400, g, 200, 301, 302)

        ' Now three more points.
        slv.AddParam(15, g, 100.0)
        slv.AddParam(16, g, 120.0)
        slv.AddPoint2d(303, g, 200, 15, 16)

        slv.AddParam(17, g, 120.0)
        slv.AddParam(18, g, 110.0)
        slv.AddPoint2d(304, g, 200, 17, 18)

        slv.AddParam(19, g, 115.0)
        slv.AddParam(20, g, 115.0)
        slv.AddPoint2d(305, g, 200, 19, 20)

        ' And arc, centered at point 303, starting at point 304, ending at
        ' point 305.
        slv.AddArcOfCircle(401, g, 200, 102, 303, 304, 305)

        ' Now one more point, and a distance
        slv.AddParam(21, g, 200.0)
        slv.AddParam(22, g, 200.0)
        slv.AddPoint2d(306, g, 200, 21, 22)

        slv.AddParam(23, g, 30.0)
        slv.AddDistance(307, g, 200, 23)

        ' And a complete circle, centered at point 306 with radius equal to
        ' distance 307. The normal is 102, the same as our workplane.
        slv.AddCircle(402, g, 200, 306, 102, 307)

        ' The length of our line segment is 30.0 units.
        slv.AddConstraint(1, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
            200, 30.0, 301, 302, 0, 0)

        ' And the distance from our line segment to the origin is 10.0 units.
        slv.AddConstraint(2, g, Slvs.SLVS_C_PT_LINE_DISTANCE, _
            200, 10.0, 101, 0, 400, 0)

        ' And the line segment is vertical.
        slv.AddConstraint(3, g, Slvs.SLVS_C_VERTICAL, _
            200, 0.0, 0, 0, 400, 0)

        ' And the distance from one endpoint to the origin is 15.0 units.
        slv.AddConstraint(4, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
            200, 15.0, 301, 101, 0, 0)

        ' And same for the other endpoint; so if you add this constraint then
        ' the sketch is overconstrained and will signal an error.
        'slv.AddConstraint(5, g, Slvs.SLVS_C_PT_PT_DISTANCE, _
        '    200, 18.0, 302, 101, 0, 0)

        ' The arc and the circle have equal radius.
        slv.AddConstraint(6, g, Slvs.SLVS_C_EQUAL_RADIUS, _
            200, 0.0, 0, 0, 401, 402)

        ' The arc has radius 17.0 units.
        slv.AddConstraint(7, g, Slvs.SLVS_C_DIAMETER, _
            200, 2 * 17.0, 0, 0, 401, 0)

        ' If the solver fails, then ask it to report which constraints caused
        ' the problem.
        slv.Solve(g, 0, 0, 0, 0, True)

        If (slv.GetResult() = Slvs.SLVS_RESULT_OKAY) Then
            'Console.WriteLine("solved okay")
            ' Note that we are referring to the parameters by their handles,
            ' and not by their index in the list. This is a difference from
            ' the C example.
            'Console.WriteLine(String.Format( _
            '"line from ({0:F3} {1:F3}) to ({2:F3} {3:F3})", _
            'slv.GetParamByHandle(11), slv.GetParamByHandle(12), _
            'slv.GetParamByHandle(13), slv.GetParamByHandle(14)))
            ''Console.WriteLine(String.Format( _
            '    "arc center ({0:F3} {1:F3}) start ({2:F3} {3:F3}) " + _
            '        "finish ({4:F3} {5:F3})", _
            '    slv.GetParamByHandle(15), slv.GetParamByHandle(16), _
            '    slv.GetParamByHandle(17), slv.GetParamByHandle(18), _
            '    slv.GetParamByHandle(19), slv.GetParamByHandle(20)))
            ''Console.WriteLine(String.Format( _
            '    "circle center ({0:F3} {1:F3}) radius {2:F3}", _
            '    slv.GetParamByHandle(21), slv.GetParamByHandle(22), _
            '    slv.GetParamByHandle(23)))

            'Console.WriteLine(slv.GetDof().ToString() + " DOF")
        Else
            'Console.Write("solve failed; problematic constraints are:")
            Dim t As UInteger
            For Each t In slv.GetFaileds()
                'Console.Write(" " + t.ToString())
            Next
            'Console.WriteLine("")
            If (slv.GetResult() = Slvs.SLVS_RESULT_INCONSISTENT) Then
                'Console.WriteLine("system inconsistent")
            Else
                'Console.WriteLine("system nonconvergent")
            End If
        End If

    End Sub


    '''''''''''''''''''''''''''''''
    ' The interface to the library, and the wrapper functions around
    ' that interface, follow.

    ' These are the core functions imported from the DLL
    <DllImport("slvs.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Public Sub Slvs_Solve(ByVal sys As IntPtr, ByVal hg As UInteger)
    End Sub

    <DllImport("slvs.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Public Sub Slvs_MakeQuaternion(
        ByVal ux As Double, ByVal uy As Double, ByVal uz As Double,
        ByVal vx As Double, ByVal vy As Double, ByVal vz As Double,
        ByRef qw As Double, ByRef qx As Double, ByRef qy As Double,
            ByRef qz As Double)
    End Sub

End Module