# BAR
Buscador de Archivos Remoto
ESPERO QUE SEA DE UTILIDAD Y DE SU AGRADO!!!!!!!!!!!!!!!!!!!!

Requerimientos para este programa:
Se requiere el uso del protocolo ssh, para este programa se uso OPEN SSH de Windows
En la PC que se usara como PC cliente Admi solo debe activarse "Cliente OPEN SSH"
y en las que se usara como servidor y se decea buscar los archivos solo se debe activar el "Servidor OPEN SSH". En la siguiente imagen se muestra en forma de diagrama (disculpen la confucion xddd).

IMPORTANTE: En la carpeta servidor debera crear las carpetas Commands y Paths!!!!!!!!!!!!!!!!!!

![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/Diagrama.png)
En este Link se muestra como activar OPEN SSH
https://www.profesionalreview.com/2018/11/30/ssh-windows-10/


La ventana de Inicio muestra las opciones para establecer la PC que se usara como Servidor
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/Bienvenido.png)

Se abre la siguitnete ventana donde se establecera el servidor, note que en la parte superior no cuenta con IP.
Por medio de una expresion se valida la IP, se puede observar en el recuadro rojo
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/confIp.png)

Tambien cuenta con una opcion predeterminada donde estrae el nombre e IP de la maquina local donde ya que sera usada como servidor
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/Predeterminado.png)

En el campo de password debe de ser el password de la maquina. Tambien se pued eobservar que contiene una validacion de confirmacion.
NOTA: Se requiere de mas prueba de errores.
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/valPass.png)

En la sigueinte imagen se puede observar la carpeta que se encuentra compartida del servidor "ServHP", esta la debe de crear y compartir.
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/carp.png)

Una vez establecido el Servidor se abrira la ventana de inicio.
Aqui se ingresara los datos de la PC donde se buscaran los archivos:
Usuario: es el nombre de usuario de la maquina
IP: IP de la maquina donde se escanearan los archivos
Password: Se requiere la contraseña de la maquina
Tipo: El tipo de escaneo Ligero es el predeterminado
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/Inicio.png)

Si deceas cambiar el servidor o te equivocaste puedes modificarlo con el link "Configurar Servidor". Se abrira la siguiente ventana
Observe que en la parte superior esta la IP actual
En la parte inferior puede cancelar o proceder con la modificación
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/IniConfigServidor.png)

En la parte de Tipo existe 2 formas Ligero y Profundo
El Ligero busca en las carpetas Document, Download y Desktop que son las genericas y mas usadas
En profundo recorre todo el arbol desde la carpeta raiz
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/InicType.png)

Cuando todo este correcto se mostrara la sigueinte ventana dara en Enter para seguir
Aqui muestra la conexion al servidor para poder ingresar los BATCH
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/abrirConex.png)

Despues se mostrara la siguiente ventana donde se hace una conexion a la PC que sera escaneada, se le pide escribir 'y' o 'n'
puede escribir 'n' sin ningun problema.
Lo que hace esta parte acceder por cmd a su PC. Una vez adentro ejecutaremos los BATCH que preparamos al inicio.
NOTA: todo el trabajo y la carga de RED es por parte de la PC cliente, en nuestra PC no hace ningun trabajo
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/conexPlink.png)

Aqui se muestra la carpeta del servidor
Commands: es donde estan guardado los BATCH
Path: es donde se crea un TXT donde la PC cliente manda todas las rutas de sus archivos (dependiendo del tipo de escaneo)
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/carpLista.png)

Es esta imagen se puede observar que el ROBOCOPY termino y creo una copia de los archivos de la PC Cliente y ahora desde nuestra PC Cliente Admi accederemos a los archivos almacenados en el servidor liberando la PC Cliente.
Observe que en recuadro superior muestra que efectivamente es el Servidor
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/carpEjemplos.png)

Esta es la imagem de la ventana donde podremos realizar nuestra busqueda
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/VentaEsca.png)

Aquí pedimos buscar la palabra "Ejemplo" y este procedera a buscar las coincidencias, si coincide con el nombre del archivo o en su contenido
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/VentanaListo.png)

Observe que estamos en PC totalmente diferenstes
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/VentanaMasEjemplo.png)

Puede visualizar los documentos al hacer doble clic sobre la celda del datagridview
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/OpenFiles.png)

Aquí abrirmos en documento desde el servidor mostrando que efectivamente hizo lectura del documento y mostrandolo en la coolumna de "Resultados" del datagridview
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/VentanaEjemploFinal.png)

Aquí se observa cuando se pieder la conexion con el servidor. Se puede mejorar esta parte para restablecer la conexion (como observacion).
Si es que la PC servidor entro en Suspension o paso demaciado tiempo.
![ScreenShot](https://raw.github.com/Gamas-G/BAR/master/Screen/ConnLost.png)
