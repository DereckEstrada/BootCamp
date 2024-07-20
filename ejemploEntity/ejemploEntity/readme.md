# PARA CREAR AUTMÁTICAMENTE DESDE ENTITYFRAMEWORK
#! INSTALAR EFCORE,EFCORE SqlServer, EFCORE TOOLS

#LUEGO VAMOS TOOLS, NUGGET MANAGER, NUGGET CONSOLE Y PEGAMOS LO SIGUIENTE
Scaffold-DbContext "Server=.;Database=TEST;Integrated Security=true;TrustServerCertificate=True;User=sa;Password=Ucg.2023" Microsoft.EntityFrameworkCore.SqlServer -o Models -f