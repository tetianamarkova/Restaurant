# Restaurant

This is POS (Point of Sale) for restaurant. This web app is functioning as a portal for managing an interactive restaurant

Before you start, please:
1. Execute the database creation script. You can find it in the fold with project - kodisoft_dt_script.sql
2. Go to the KodisoftTest -> KodisoftTest -> Web.config
3. Find the connection string:

 ``` <connectionStrings>
    <add name="Restaurant" connectionString="data source=WINDOWS-QLB7GJD;initial catalog=Kodisoft;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework" providerName="System.Data.SqlClient" />
  </connectionStrings>```
  
4. And replace it with the connection string of you newly created database
5. Only after that, you can run the project
