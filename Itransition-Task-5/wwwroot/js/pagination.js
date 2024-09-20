function isElementInViewport(el) {
    const rect = el.getBoundingClientRect();

    return (
        rect.top >= 0 &&
        rect.left >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
        rect.right <= (window.innerWidth || document.documentElement.clientWidth)
    );
}

async function handleScroll() {
    const targetDiv = document.getElementById('loader');

    if (isElementInViewport(targetDiv) && isAvaliable) {
        await fetchUsers(false, 10);
    }
}

window.addEventListener('scroll', handleScroll);