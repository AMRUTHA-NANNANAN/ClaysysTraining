// JavaScript source code
const parentContainer = document.querySelector('.hero-content');
parentContainer.addEventListner('click', event => {
    const current = event.target;
    const isReadMoreBtn = current.className.includes('.read-more-btn');
    if (!isReadMoreBtn) return;

    const currentText = event.target.parentNode.querySelector('.read-more-text');

    currentText.classList.toggle('.read-more-text--show');
    current.textContent = current.textContent.includes('Read More') ?"read Less.." : "Read More...";
})
