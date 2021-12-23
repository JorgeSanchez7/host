<?php


//Llamando a los campos
	$nombre = $_POST["nombre"];
	$correo = $_POST["correo"];
	$telefono= $_POST["telefono"];
	$mensaje = $_POST["mensaje"];
	$para = "jorgesanchezramos7@gmail.com";
	
	
//Datos para el correo
	$asunto ="Contacto desde nuestra web-personal";
	
	$mensaje = "
    Nombre del remitente: ".$nombre."
	Asunto: ".$asunto."
    Telefono del remitente: ".$telefono."
    correo: ".$correo."
    mensaje: ".$mensaje."
  ";
	
//Enviando mensaje

	if(mail($para,$correo,utf8_decode($mensaje)))
    echo "<script type='text/javascript'>alert('Tu mensaje ha sido enviado exitosamente');</script>";

    echo "<script type='text/javascript'>window.location.href='Jorge Sanchez Ramos-Inicio.html';</script>";
	

?>