
    document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('registrationForm');
    const firstName = document.getElementById('Input_FirstName');
    const lastName = document.getElementById('Input_LastName');
    const email = document.getElementById('Input_Email');
    const password = document.getElementById('Input_Password');
    const confirmPassword = document.getElementById('Input_ConfirmPassword');
    const termsCheckbox = document.getElementById('Terms');

    form.addEventListener('submit', function(event) {
        let isValid = true;
    document.querySelectorAll('.validation-message').forEach(function(message) {
        message.remove(); 
        });

    if (firstName.value.length < 2) {
        displayValidationMessage(firstName, 'First name must be at least 2 characters long');
    isValid = false;
        }

    if (lastName.value.length < 2) {
        displayValidationMessage(lastName, 'Last name must be at least 2 characters long');
    isValid = false;
        }

    if (!validateEmail(email.value)) {
        displayValidationMessage(email, 'Please enter a valid email address');
    isValid = false;
        }

    if (password.value.length < 8) {
        displayValidationMessage(password, 'Password must be at least 8 characters long');
    isValid = false;
        }

    if (password.value !== confirmPassword.value) {
        displayValidationMessage(confirmPassword, 'Passwords do not match');
    isValid = false;
        }

    if (!termsCheckbox.checked) {
        displayValidationMessage(termsCheckbox, 'You must agree to the terms and conditions');
    isValid = false;
        }

    if (!isValid) {
        event.preventDefault(); 
        }
    });

    function displayValidationMessage(inputElement, message) {
        const messageElement = document.createElement('div');
    messageElement.classList.add('validation-message');
    messageElement.style.color = 'red';
    messageElement.textContent = message;
    inputElement.parentElement.appendChild(messageElement);
    }

    function validateEmail(email) {
        return /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email);
    }
    });




