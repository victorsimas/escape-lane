function validate() {
    if(nome.value.length < 3){
		alert("INFORME UM NOME DESCENTE ***");
		nome.focus();
		return false;
	}
	if(email.value.length < 8 || 
		email.value.indexOf("@") <=0 ||
		email.value.indexOf(".") <=0){
		alert("INFORME A *** DO SEU EMAIL");
		email.focus();
		return false;
	}
	if(fone.value.length > 9 || isNaN(fone.value)){
		alert("INFORME O NUMERO DE TELEFONE ***");
		fone.focus();
		return false;	
	}
}