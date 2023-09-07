const citiesByState = {
    assam: ["Dhuburi", "Dibrugarh", "Dispur", "Guwahati", "Jorhat", "Nagaon", "Sivasagar", "Silchar", "Tezpur" < "Tinsukia"],
    goa: ["Madgaon", "Panajil"],
    karnataka: ["Bengaluru","Belagavi","Bhadravati","Bidar","Chikkamagaluru","Chitradurga","Davangere","Halebid","Hassan","Hubballi - Dharwad","Kalaburagi","Kolar","Madikeri","Mandya","Mangaluru","Mysuru","Raichur","Shivamogga","Shravanabelagola","Shrirangapattana","Tumakuru","Vijayapura"],
    kerala: ["Alappuzha", "Vatakara", "Idukki", "Kannur", "Kochi", "Kollam", "Kottayam", "Kozhikode", "Mattancheri", "Palakkad", "thalassery", "Thiruvananthapuram", "Thrissur"],
    sikkim: ["Gangtok","Gyalshing","Lachung","Mangan"]
    }
function populateCities() {
    const stateSelect = document.getElementById("state");
    const citySelect = document.getElementById("city");

   
    citySelect.innerHTML = "<option value=''>Select a city</option>";

    const selectedState = stateSelect.value;

    
    if (selectedState && citiesByState[selectedState]) {
        citiesByState[selectedState].forEach(city => {
            const option = document.createElement("option");
            option.value = city;
            option.text = city;
            citySelect.appendChild(option);
        });
    }
}
function Findage() {
    var day = document.getElementById("date").value;
    var DOB = new Date(day);
    var today = new Date();
    var age = today.getTime() - DOB.getTime();
    age = Math.floor(age / (1000 * 60 * 60 * 24 * 365.25));
    document.getElementById("age").value = age;
}

const form = document.querySelector('#form');
const fname = document.querySelector('#fname');
const lname = document.querySelector('#lname');
const submit = document.querySelector('#submit');
const email = document.querySelector('#email');
const password = document.querySelector('#password');
const phone = document.querySelector('#phone');
const age = document.querySelector('#age');
const confirmPassword = document.querySelector('#confirmPassword');
const address = document.querySelector('#address');





form.addEventListener('submit', (event) => {
    event.preventDefault();
    //firstname
    if (fname.value.trim() == '') {
        error(fname, 'Firstname cannot be empty!');
    } else if (fname.value.trim().length < 4 || fname.value.trim().length > 15) {
        error(fname, 'Firstname should have characters in between 4 and 15! ');
    } else if (isFnameValid(fname.value)) {
        success(fname);
    }
    else {
        error(fname, 'Firstname contains only letters and spaces!');
    }

    //lastname
    if (lname.value.trim() == '') {
        error(lname, 'Lastname cannot be empty!');
    } else if (lname.value.trim().length < 4 || lname.value.trim().length > 15) {
        error(lname, 'Lastname should have characters in between 4 and 15! ');
    }
    else if (isLnameValid(lname.value)) {
        success(lname);
    }
    else {
        error(lname, 'Lastname contains only letters and spaces!');
    }

    //email
    if (email.value.trim() == '') {
        error(email, 'Email cannot be empty');
    } else if (isEmailValid(email.value)) {
        success(email);
    }
    else {
        error(email, 'Provide valid email address!');
    }

    //password
    if (password.value.trim() == '') {
        error(password, 'Password can not be empty!');
    } else if (isPasswordValid(password.value))
    {
        success(password);
    }
    else {
        
        error(password, 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.');
    }

     //phone
    if (phone.value.trim() == '') {
        error(phone, 'Phone number cannot be empty!');
    }
    else if (isPhoneValid(phone.value)) {
        success(phone);
    }
    else {
        error(phone, 'Provide valid phone number!');
    }

    //username
    if (username.value.trim() == '') {
        error(username, 'Username cannot be empty!');
    } else if (username.value.trim().length < 4 || username.value.trim().length > 15) {
        error(username, 'Username should have characters in between 4 and 15! ');
    }
    else if (isUsernameValid(username.value)) {
        success(username);
    }
    else {
        error(username, 'username contains only letters, digits, and underscores!');
    }
    
    //age

    if (isAgeValid(age.value)) {
        success(age);
    }
    else {
        error(age, 'Please enter a valid age between 18 and 45.');
    }
    //Cpassword

    if (confirmPassword.value.trim() == '') {
        error(confirmPassword, 'confirmPassword cannot be empty!');
    } else if (password.value.trim() !== confirmPassword.value.trim()) {
        error(confirmPassword, 'Passwords do not match!');

    } else {
        success(confirmPassword);
    }
    //address
    if (address.value.trim() == '') {
        error(address, 'Address cannot be empty!');

    } else {
        success(address);
    }

   

});


function error(element, msg) {
    element.style.border = '3px red solid';
    const parent = element.parentElement;
    const p = parent.querySelector('p');
    p.textContent = msg;
    p.style.visibility = 'visible';
}
function success(element) {
    element.style.border = '3px green solid';
    const parent = element.parentElement;
    const p = parent.querySelector('p');
  
    p.style.visibility = 'hidden';
}

        //email-validation
function isEmailValid(email) {
    const reg = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return reg.test(email);
}

function isPasswordValid(password) {
    const re = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$/;
    return re.test(password);
}

function isLnameValid(lname) {
    const reg = /^[a-zA-Z\s]+$/;
    return reg.test(lname);
}

function isFnameValid(fname) {
    const rg = /^[a-zA-Z\s]+$/;
    return rg.test(fname);

}
function isPhoneValid(phone) {
    const reg = /^\d{10}$/;
    return reg.test(phone);
} 

function isUsernameValid(username) {
    const reg = /^[a-zA-Z0-9_]+$/;
    return reg.test(username);
}

function isAgeValid(age){
    return age >= 18 && age <= 45;
}

