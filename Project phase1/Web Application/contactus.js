// JavaScript source code
function validate() {
    var fullname = document.getElementById("fullname");
    var email = document.getElementById("email");
    var msg = document.getElementById("msg");

   
    if (fullname.value == "") {
        alert("must have a username");
        document.form.fullname.focus();
        return false;
    }
    if (email.value == "") {
        alert("Please enter a valid e-mail address");
        document.form.email.focus();
        return false;
    }
    if (msg.value == "") {
        alert("must have a message");
        document.form.msg.focus();
        return false;
    }    
};
function myfunction() {
    let x = document.getElementById("email");
    x.value = x.value.toLowerCase();
};