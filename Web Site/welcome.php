<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="lib/bootstrap.css">
</head>

<body>
    <div id="main-menu"></div>
    <img src="images/welcome.png" width="100%" height="100%" />
    <div id="magicka">
        <div class="row">
            <div class="col-md-6">
                <h3>
                    Nossos parceiros
                </h3>
                <p>
                    Seja bem vindo a equipe! Aguardamos ansiosamente pela sua experiência e desejamos uma boa sorte no
                    nosso processo seletivo!
                    <br/><br/><br/>
                    Aqui segue a lista de candidatos inscritos!
                </p>
                <br/>
                <br/>
                <p>Para encerrar esta sessão, clique em:</p>
                <p>
                    <a class="btn" href="src/logout.php">Sair >></a>
                </p>
            </div>
            <div class="col-md-6">
                <table id="result" border="1" style="margin-top: 20px; margin-bottom: 20px">
                </table>
                Agradecemos a todos que se inscreveram pelo apoio, sucesso!
            </div>
        </div>
    </div>
</body>
<script lang="javascript" src="lib/jquery-3.4.0.min.js"></script>
<script lang="javascript" src="lib/bootstrap.min.js"></script>
<script lang="javascript" src="src/jquery_script.js"></script>
<script lang="javascript" src="lib/popper.min.js"></script>
<script lang="javascript" src="src/ajax.js"></script>
</html>

<?php
	session_start();
	if(isset($_SESSION["name"])){
        return;
	} else {
		header("location: contact.html");
	}
?>
