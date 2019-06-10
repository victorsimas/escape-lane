function validate() {
    if (nome.value == "") {
        alert("PLEASE INSERT A FUCKING NAME");
        nome.focus();
        return false;
    }
    if (email.value == "" ||
        email.value.indexOf("@") <= 0 ||
        email.value.lastIndexOf(".") <=
        email.value.indexOf("@") <= 0) {
        alert("YOUR SHIT MAIL IS NOT VALID!");
        email.focus();
        return false;
    }
    if (telefone.value == "" ||
        isNaN(telefone.value) == true ||
        telefone.value.length > 11) {
        alert("WHAT THE HECK IS THIS? NOT RIGHT DUDE");
        telefone.focus();
        return false;
    }
}