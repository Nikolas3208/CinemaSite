// script.js

// Функція для перемикання видимості пароля
function togglePasswordVisibility(inputId, buttonId) {
    const passwordInput = document.getElementById(inputId);
    const toggleButton = document.getElementById(buttonId);

    toggleButton.addEventListener('click', () => {
        if (passwordInput.type === 'password') {
            passwordInput.type = 'text'; // Відкриваємо пароль
            toggleButton.textContent = '🙈'; // Змінюємо іконку
        } else {
            passwordInput.type = 'password'; // Приховуємо пароль
            toggleButton.textContent = '👁️'; // Змінюємо іконку
        }
    });
}

// Виклик функції для відповідних елементів
togglePasswordVisibility('password', 'toggle-password');
