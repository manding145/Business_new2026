Imports System.Data
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module Connection

    Public applicationID_search As String
    Public appointmentID_search, recordid_search As Integer
    Public namefile, myemail, mypassword, link_prefix, lblfname1, lbluserrole1 As String
    Public FormStatus As Boolean
    Public username, password, userfullname, userid1, userid, userlevelid, TypeCard As String
    Public formid As Integer

    Public link_UnifiedForm, link_BrgyClearance, link_OldPermit, link_OldPlate, link_Fire, link_OldITR, link_MarketClearance

    Public folder_directory = "BUSINESS_APPLICATION\"


    'mysql string
    Public Con As SqlConnection
    Public cmd As SqlCommand
    Public rdr As SqlDataReader = Nothing
    Public adp As SqlDataAdapter
    Public sbuldr As SqlCommandBuilder

    Public Con2 As SqlConnection
    Public cmd2 As SqlCommand
    Public rdr2 As SqlDataReader = Nothing
    Public adp2 As SqlDataAdapter
    Public sbuldr2 As SqlCommandBuilder

    Public Con6 As SqlConnection
    Public cmd6 As SqlCommand
    Public rdr6 As SqlDataReader = Nothing
    Public adp6 As SqlDataAdapter
    Public sbuldr6 As SqlCommandBuilder

    Public conn, conn2, PhoneNumber As String
    Public type_transaction As Integer

    'MSSQL
    Public Con1 As SqlConnection
    Public cmd1 As SqlCommand
    Public rdr1 As SqlDataReader = Nothing
    Public adp1 As SqlDataAdapter
    Public sbuldr1 As SqlCommandBuilder
    Public conn1 As String


    Public Con3 As SqlConnection
    Public cmd3 As SqlCommand
    Public rdr3 As SqlDataReader = Nothing
    Public adp3 As SqlDataAdapter
    Public sbuldr3 As SqlCommandBuilder

    Public conn3 As String
    Public Con4 As SqlConnection
    Public cmd4 As SqlCommand
    Public rdr4 As SqlDataReader = Nothing
    Public adp4 As SqlDataAdapter
    Public sbuldr4 As SqlCommandBuilder
    Public conn4 As String

    'MSSQL
    Public Con_ms As SqlConnection
    Public cmd_ms As SqlCommand
    Public rdr_ms As SqlDataReader = Nothing
    Public adp_ms As SqlDataAdapter
    Public sbuldr_ms As SqlCommandBuilder
    Public conn_ms As String

    Public Con_ms1 As SqlConnection
    Public cmd_ms1 As SqlCommand
    Public rdr_ms1 As SqlDataReader = Nothing
    Public adp_ms1 As SqlDataAdapter
    Public sbuldr_ms1 As SqlCommandBuilder
    Public conn_ms1 As String


    Public Con_ms2 As SqlConnection
    Public cmd_ms2 As SqlCommand
    Public rdr_ms2 As SqlDataReader = Nothing
    Public adp_ms2 As SqlDataAdapter
    Public sbuldr_ms2 As SqlCommandBuilder
    Public conn_ms2 As String

    Public Con_ms3 As SqlConnection
    Public cmd_ms3 As SqlCommand
    Public rdr_ms3 As SqlDataReader = Nothing
    Public adp_ms3 As SqlDataAdapter
    Public sbuldr_ms3 As SqlCommandBuilder
    Public conn_ms3 As String


    Public Con_ms4 As SqlConnection
    Public cmd_ms4 As SqlCommand
    Public rdr_ms4 As SqlDataReader = Nothing
    Public adp_ms4 As SqlDataAdapter
    Public sbuldr_ms4 As SqlCommandBuilder
    Public conn_ms4 As String

    'Public cs As String = "Server=RONALDORONOC123;Database=Queue;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs As String = "Server=RONALDORONOC123;Database=Master;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs2 As String = "Server=RONALDORONOC123;Database=GeoTos;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs1 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"C:\TACLOBAN\BusinessOnlineRenewal\WindowsApplication1\Connection.vb
    'Public cs3 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"

    ''Public cs As String = "Server=10.0.0.2;Database=Master;User ID=sa;Password=@dm1n1str@t0r;"
    'Public cs1 As String = "Server=10.0.0.2;Database=CHO;User ID=sa;Password=@dm1n1str@t0r;"
    ''Public cs2 As String = "Server=10.0.0.2;Database=GeoTos;User ID=sa;Password=@dm1n1str@t0r;"
    ''Public cs3 As String = "Server=10.0.0.2;Database=CHO;User ID=sa;Password=@dm1n1str@t0r;"
    ''Public cs4 As String = "Server=10.0.0.2;Database=GeoRecords;User ID=sa;Password=@dm1n1str@t0r;"


    Public mcs As String = "Server=10.0.0.2;Database=BPLS;User ID=sa;Password=@dm1n1str@t0r;"
    Public mcs1 As String = "Server=10.0.0.2;Database=CORE_PATAS;User ID=sa;Password=@dm1n1str@t0r;"



    'Public mcs As String = "Server=10.0.3.174;Database=BPLSWEBREC;User ID=sa;Password=@dm1n1str@t0r;"

    ''MYSQL
    Public cs As String = "Server=10.0.14.117;Database=BPLS;User ID=usera2;Password=passa2;Connect Timeout=200; pooling='true';Max Pool Size=10000"

    'MSSQL
    Public cs1 As String = "Server=10.0.0.2;Database=GeoRecords;User ID=sa;Password=@dm1n1str@t0r;"
    Public cs3 As String = "Server=10.0.0.2;Database=GeoTos;User ID=sa;Password=@dm1n1str@t0r;"


    'mymsq

    'Public cs1 As String = "Server=10.0.5.76;Database=GeoRecords;User ID=sa;Password=P@$$W0RD;"
    'Public cs3 As String = "Server=10.0.5.76.251;Database=GeoTos;User ID=sa;Password=P@$$W0RD;"


    Public cs4 As String = "Server=10.0.14.117;Database=businessportal;User ID=usera2;Password=passa2;Connect Timeout=200; pooling='true';Max Pool Size=10000"
    ' Public cs4 As String = "Server=" & My.Settings.Server & ";Database=GeoRecords;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";Connect Timeout=200; pooling='true';Max Pool Size=100000"



    'Public cs2 As String = "Server=" & My.Settings.Server & ";Database=GeoTos;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs3 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"



    'Public cs As String = "Server=" & My.Settings.Server & ";Database=Master;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs1 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs2 As String = "Server=" & My.Settings.Server & ";Database=GeoTos;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs3 As String = "Server=" & My.Settings.Server & ";Database=CHO;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
    'Public cs4 As String = "Server=" & My.Settings.Server & ";Database=GeoRecords;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"

    'Public cs As String = "Server=RONALDORONOC123;Database=Master;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs2 As String = "Server=RONALDORONOC123;Database=GeoTos;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs1 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs3 As String = "Server=RONALDORONOC123;Database=CHO;User ID=sa;Password=@dm1n1$tr@t0r;"
    'Public cs4 As String = "Server=RONALDORONOC123;Database=GeoRecords;User ID=sa;Password=@dm1n1$tr@t0r;"
End Module
