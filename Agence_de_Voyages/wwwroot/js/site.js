const openModalButton = document.getElementById('openModal');
const modal = document.getElementById('modal');

openModalButton.addEventListener('click', () => {
    modal.style.display = 'block';
  
});

// JavaScript to close the modal
const closeModalButton = document.getElementById('closeModal');
closeModalButton.addEventListener('click', () => {
    modal.style.display = 'none';
});

// JavaScript to handle the login and cancel actions
const loginForm = document.getElementById('loginForm');
const loginButton = document.getElementById('loginButton');
const cancelButton = document.getElementById('cancelButton');


loginButton.addEventListener('click', () => {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Create a data object to send to the server
    const data = {
        username: username,
        password: password
    };

    fetch('/User_validation/ValidateUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(data => {
            if (data) {
                // User validation successful, you can redirect or perform other actions here
                alert('Login successful');
                // Close the modal
                modal.style.display = 'none';
            } else {
                // User validation failed, show an error message
                alert('Login failed. Please check your credentials.');
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
});


cancelButton.addEventListener('click', () => {
    // Clear the input fields
    document.getElementById('username').value = '';
    document.getElementById('password').value = '';
   
    // Close the modal
    modal.style.display = 'none';
});







