<%
On Error Resume Next ' Error handling

Response.Write("Welcome to the Employer Portal")
Dim username, sql, conn, rs

' Check the user given value for username
username = Trim(Request("username"))
If username = "" Then
    Response.Write("Invalid username")
    Response.End
End If

' Parametrized queries
Set conn = Server.CreateObject("ADODB.Connection")
conn.Open "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=MyDatabase;User ID=sa;Password=YourPassword"

Set cmd = Server.CreateObject("ADODB.Command")
cmd.ActiveConnection = conn
cmd.CommandText = "SELECT name FROM users WHERE username = ?"
cmd.Parameters.Append cmd.CreateParameter("@username", 200, 1, 255, username)

Set rs = cmd.Execute

If Not rs.EOF Then
    Response.Write("Hello, " & Server.HTMLEncode(rs("name")))
Else
    Response.Write("User not found.")
End If

' Clean resources
rs.Close
Set rs = Nothing
conn.Close
Set conn = Nothing
%>