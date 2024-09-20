const GetRequestParams = (count) => {
    const seed = document.querySelector("#seed").value;
    const localization = document.querySelector("#region").value;

    return `?Seed=${seed}&Localization=${localization}&Error=${numberInput.value}&Page=${page}&Count=${count}`;
}

async function fetchUsers(clear = false, count = 20) {
    isAvaliable = false;

    if (clear) {
        page = 0;
    }

    const response = await fetch(`/home/users${GetRequestParams(count)}`);
    const htmlContent = await response.text();
    const usersDiv = document.querySelector('.users');

    if (clear) {
        usersDiv.innerHTML = "";
        document.documentElement.scrollTop = 0;
    }

    usersDiv.innerHTML += htmlContent;
    page++;

    await new Promise(resolve => requestAnimationFrame(resolve));
    isAvaliable = true;
}

document.addEventListener('DOMContentLoaded', fetchUsers);