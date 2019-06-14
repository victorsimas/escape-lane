<?php
	$con = new mysqli("localhost","zimas","","escape_lane");
	$sql = "select * from users";
	$res = mysqli_query($con,$sql);
	while($reg = mysqli_fetch_array($res)){
		echo "<tr><td>". $reg["id"] . "</td>";
		echo "<td>". $reg["name"] . "</td>";
		echo "<td>". $reg["email"] . "</td>";
		echo "<td>". $reg["fone"] . "</td></tr>";

	}
	$con->close();
?>