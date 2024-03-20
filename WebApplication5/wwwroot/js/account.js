const updateDetailsForm = document.getElementById('updateDetailsForm');
const updateAddressForm = document.getElementById('updateAddressForm');

const updateDetailsValidationSettings = {
    'FirstName': { required: true, message: 'First name is required.' },
    'LastName': { required: true, message: 'Last name is required.' },
    'Email': { required: true, validateFunc: validateEmail, message: 'A valid email address is required.' },
    'PhoneNumber': { required: false },
    'Bio': { required: false }
};

const updateAddressValidationSettings = {
    'AddressLine1': { required: true, message: 'Address Line 1 is required.' },
    'PostalCode': { required: true, message: 'Postal code is required.' },
    'City': { required: true, message: 'City is required.' }
};

function setupValidation(form, validationSettings) {
    if (form) {
        form.addEventListener('submit', function (event) {
            let isValid = true;
            clearValidationMessages();

            Object.entries(validationSettings).forEach(([fieldId, rules]) => {
                const inputElement = form.querySelector(`#${fieldId}`);
                if (inputElement) {
                    const value = inputElement.value.trim();
                    if (rules.required && !value) {
                        displayValidationMessage(inputElement, rules.message);
                        isValid = false;
                    }
                    if (rules.validateFunc && !rules.validateFunc(value)) {
                        displayValidationMessage(inputElement, rules.message);
                        isValid = false;
                    }
                }
            });

            if (!isValid) {
                event.preventDefault(); /
            }
        });
    }
}

setupValidation(updateDetailsForm, updateDetailsValidationSettings);
setupValidation(updateAddressForm, updateAddressValidationSettings);
