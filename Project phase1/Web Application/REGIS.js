// JavaScript source code
const form = document.getElementById('form');
const username = document.getElementById('fname');
const email = document.getElementById('email');
const psw = document.getElementById('psw');

    form.addEventListner('submit', e => {
        e.preventDefault();
        validateInputs();
    });
    const setError = (element, message) => {
        const inputControl = element.parentElement;
        const errorDisplay = inputControl.querySelector('.error');

        errorDisplay.innerText = message;
        inputControl.classList.add('error');
        inputControl.classList.remove('success')
    }

    const setSuccess = element => {
        const inputControl = element.parentElement;
        const errorDisplay = inputControl.querySelector('.error');

        errorDisplay.innerText = '';
        inputControl.classList.add('success');
        inputControl.classList.remove('error');
    };

    const isValidEmail = email => {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }
    const validateInputs = () => {
       
        const usernameValue = fname.value.trim();
        const emailValue = email.value.trim();
        const passwordValue = psw.value.trim();

        if (usernameValue === '') {
            setError(fname, 'Username is required');
        } else {
            setSuccess(fname);
        }

        if (emailValue === '') {
            setError(email, 'Email is required');
        } else if (!isValidEmail(emailValue)) {
            setError(email, 'Provide a valid email address');
        } else {
            setSuccess(email);
        }

        if (passwordValue === '') {
            setError(psw, 'Password is required');
        } else if (passwordValue.length < 8) {
            setError(psw, 'Password must be at least 8 character.')
        } else {
            setSuccess(psw);
        }



    };

    


