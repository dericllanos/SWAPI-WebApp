/* Pagination
-------------------------------------------------- */
var num = 1;
if (sessionStorage.getItem('num') == null) {
    num = 1;
    sessionStorage.setItem('num', num);
    document.getElementById('prev').disabled = true;
}
else {
    document.getElementById('default').style.display = "none";
    num = sessionStorage.getItem('num', num);
    if (num <= 1) {
        document.getElementById('prev').disabled = true;
    }
    if (num >= 9) {
        document.getElementById('next').disabled = true;
    }
}
function nextPage() {
    num++;
    saveAndLoad();
}
function prevPage() {
    num--;
    saveAndLoad();
}
function saveAndLoad() {
    sessionStorage.setItem('num', num);
    window.location = "?page=" + num;
}