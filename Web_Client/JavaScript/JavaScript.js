var xhr = new XMLHttpRequest();

xhr.open('Get', 'http://localhost:64197/api/wizzard', true);

xhr.onload = function () {
    console.log(this.responseText);
};

xhr.send();