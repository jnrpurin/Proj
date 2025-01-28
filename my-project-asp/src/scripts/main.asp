<%
Response.Write("Welcome to the Employer Portal")
Dim username, sql, rs
username = Request("username")

' Use parameterized query to prevent SQL Injection
Set cmd = Server.CreateObject("ADODB.Command")
cmd.ActiveConnection = conn
cmd.CommandText = "SELECT * FROM users WHERE username = ?"
cmd.Parameters.Append cmd.CreateParameter("@username", 200, 1, 50, username)

Set rs = cmd.Execute()

If Not rs.EOF Then
    Response.Write("Hello, " & rs("name"))
Else
    Response.Write("User not found.")
End If
%>