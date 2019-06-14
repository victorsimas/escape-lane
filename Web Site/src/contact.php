<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="../lib/bootstrap.css">
</head>
<script lang="javascript" src="../lib/jquery-3.4.0.min.js"></script>
<script src="../lib/bootstrap.min.js"></script>
<script lang="javascript" src="jquery_script.js"></script>
<script src="../lib/popper.min.js"></script>
</html>

<?php
if(isset($_POST["button_email"])){
	sendEmail();
}	

// EMAIL E CADATRAMENTO DE CONTATO

function sendEmail(){
	$name = $_POST["name"];
	$email = $_POST["email"];
	$fone  = $_POST["fone"]; 
	$subject = "Well this is an hello";
	$body = "I would like to join your pretty organization";
	$msg = $name.$body;
	$header = "MIME-Version: 1.0\r\n";
	$header .= "from: teste<fatecpwAds2016@outlook.com>";

	if(saveContact($name, $email, $fone)){
		mail($email, $subject, $msg, $header);
		echo "Enviamos um email ao seu usuário, Bem vindo!";
		header('Location: ../welcome.html'); 
	}
	else {
		echo "Usuário já cadastrado";
	}
}

function saveContact($name, $email, $fone){
	$con = new mysqli("localhost", "zimas", "", "escape_lane");
	if(checkIfExists($con, $email, $fone)){
		return false;
	}
	$sql = "insert into users(name, email, fone, date_access) values('$name','$email','$fone',now())";
	mysqli_query($con, $sql);
	$con->close();
	return true;
}

function checkIfExists($con, $email, $fone){
	$sql = "select email,fone from users where email = '$email' OR fone = '$fone'";
	$result =  mysqli_query($con, $sql);
	if ($registre = mysqli_fetch_array($result)){
		return true;
	}
	else {
		return false;
	}

}
?>