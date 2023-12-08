
const usernameElement = document.querySelector('.clearfix strong');
const imageElement = document.querySelector('.clearfix img');
if (usernameElement && imageElement) {
    const username = usernameElement.textContent.trim();
    const imageUrl = imageElement.getAttribute('src');

    alert(`Username: ${username}\nImage URL: ${imageUrl}`);
} else {
    alert('Could not find the required elements in the HTML.');
}
