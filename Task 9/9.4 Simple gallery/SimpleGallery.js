var urls = ["/SimpleGallery.html", "/2.html", "/3.html"];
var index;
var path = window.location.href;

window.onload = function () {    
    function bindButtons() {
        var p = document.getElementById("pause");
        p.addEventListener("click", timer.pause, false);

        var r = document.getElementById("resume");
        r.addEventListener("click", timer.resume, false);

        var pr = document.getElementById("previous");
        pr.addEventListener("click", previous, false);
    }

    index = getIndexOfCurrentPage();
    if (urls[index] === urls[urls.length - 1]) {
            var isRestart = confirm("Press 'OK' to restart or 'Cancel' to close tab");
            if (isRestart) {          
                var link = path.replace(urls[index], urls[0]);
                document.location.href = link;
            }
            else {     
                window.close();
            }
        }

    var display = document.getElementById("time");
    var timer = new Timer(1000, 5, display);
    bindButtons();
};

function Timer(del, duration, disp) 
{
    var timerId, delay = del, time = duration, 
    minutes, seconds, display = disp;

    this.pause = function() {
        window.clearInterval(timerId);
    };

    this.resume = function() {        
        window.clearInterval(timerId);
        timerId = window.setInterval(function() {            
            minutes = parseInt(time / 60, 10)
            seconds = parseInt(time % 60, 10);
    
            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;
    
            display.textContent = minutes + ":" + seconds;
    
            if (--time < 0) {         
                var link = path.replace(urls[index], urls[index + 1]);
                document.location.href = link;
            }
        }, delay);
    };

    this.resume();
}

function previous() {
    if (index === 0)
        return;
         
    var link = path.replace(urls[index], urls[index - 1]);
    document.location.href = link;
}

function getIndexOfCurrentPage() {
    for (var i = 0; i < urls.length; i++)
            if (path.indexOf(urls[i], 0) !== -1)
                return i;
}
