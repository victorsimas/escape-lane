<?php
	if(isset($_POST["button_email"])){
		sendEmail();
	}	

	// EMAIL E CADASTRAMENTO DE CONTATO
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
			header('Location: ../sendmail.html');
		}
		else {
			header('Location: ../welcome.php'); 
		}
	}

	function saveContact($name, $email, $fone){
		$con = new mysqli("localhost", "zimas", "", "escape_lane");
		if(checkIfExists($con, $email, $fone)){
			$con->close();
			return false;
		} 
		$sql = "insert into users(name, email, fone, date_access) values('$name','$email','$fone',now())";
		mysqli_query($con, $sql);
		$con->close();
		return true;
	}

	function checkIfExists($con, $email, $fone){
		$sql = "select id, name from users where email = '$email' AND fone = '$fone'";
		$result =  mysqli_query($con, $sql);

		if ($reg = mysqli_fetch_array($result)){
			session_start();
			$_SESSION["id"] = $reg["id"];
			$_SESSION["name"] = $reg["name"];
			return true;
		}
		else {
			return false;
		}
		

	}
?>