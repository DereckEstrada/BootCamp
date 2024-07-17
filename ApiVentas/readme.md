# PARA CREAR AUTMÁTICAMENTE DESDE ENTITYFRAMEWORK
#! INSTALAR EFCORE,EFCORE SqlServer, EFCORE TOOLS

#LUEGO VAMOS TOOLS, NUGGET MANAGER, NUGGET CONSOLE Y PEGAMOS LO SIGUIENTE
Scaffold-DbContext "Server=.;Database=TEST;Integrated Security=true;TrustServerCertificate=True;User=sa;Password=Ucg.2023" Microsoft.EntityFrameworkCore.SqlServer -o Models -f

# CONFIGURACION DESDE GIT
"ConnectionDefault": " Server=DERECK\\SQLEXPRESS; Database=BASE_ERP; Integrated Security=true; TrustServerCertificate=true"

# CONFIGURACION DE DMS GIT
"DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=BASE_ERP;Integrated Security=true;TrustServerCertificate=True;User=sa;Password=Ucg.2023"