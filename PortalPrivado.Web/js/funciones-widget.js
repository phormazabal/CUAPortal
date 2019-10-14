const cSlide = document.getElementsByClassName('c-slide');
if(cSlide){
[].forEach.call(document.querySelectorAll('.c-slide'), function (el) {
  var slider = tns({
    container: el,
    items: 1,
    controls: false,
    nav: true,
    navPosition: 'bottom',
    preventScrollOnTouch: "force",
    autoplay: true,
    autoplayTimeout: 4500,
    autoplayButtonOutput: false,
    autoplayHoverPause: true,
    mouseDrag: true
    });
  });
}

const c1 = document.getElementsByClassName('c-1');
if(c1){
[].forEach.call(document.querySelectorAll('.c-1'), function (el) {
  var slider = tns({
    container: el,
    items: 1,
    controls: false,
    nav: true,
    navPosition: 'bottom',
    gutter: 15,
    preventScrollOnTouch: "force"
    });
  });
}
const c1p = document.getElementsByClassName('c-1-play');
if(c1p){
[].forEach.call(document.querySelectorAll('.c-1-play'), function (el) {
  var slider = tns({
    container: el,
    items: 1,
    controls: false,
    nav: true,
    navPosition: 'bottom',
    gutter: 15,
    preventScrollOnTouch: "force",
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayButtonOutput: false,
    autoplayHoverPause: true,
    mouseDrag: true
    });
  });
}

const carrusel2 = document.getElementsByClassName('c-2');
if(carrusel2){
[].forEach.call(document.querySelectorAll('.c-2'), function (el) {
  var slider = tns({
      container: el,
      items: 2,
      controls: true,
      nav: true,
      navPosition: 'bottom',
      gutter: 30,
      preventScrollOnTouch: "force",
      responsive: {
          0: {
              items: 1
          },
          550: {
            items: 2
          },
          768: {
              items: 2
          },
          991: {
            items: 2
          },
          1200: {
            items: 2
          }
      }
    });
  });
}
const carrusel3 = document.getElementsByClassName('c-3');
if(carrusel3){
[].forEach.call(document.querySelectorAll('.c-3'), function (el) {
  var slider = tns({
      container: el,
      items: 3,
      controls: true,
      nav: true,
      navPosition: 'bottom',
      gutter: 15,
      preventScrollOnTouch: "force",
      responsive: {
          0: {
              items: 1
          },
          640: {
            items: 2
          },
          768: {
              items: 3
          },
          991: {
            items: 3
          },
          1200: {
            items: 3
          }
      }
    });
  });
}
const carrusel3s = document.getElementsByClassName('c-3-seguros');
if(carrusel3){
[].forEach.call(document.querySelectorAll('.c-3-seguros'), function (el) {
  var slider = tns({
      container: el,
      items: 3,
      controls: true,
      nav: true,
      navPosition: 'bottom',
      gutter: 15,
      preventScrollOnTouch: "force",
      responsive: {
          0: {
              items: 1
          },
          640: {
            items: 2
          },
          768: {
              items: 2
          },
          991: {
            items: 2
          },
          1200: {
            items: 3
          }
      }
    });
  });
}
const carrusel4 = document.getElementsByClassName('c-4');
if(carrusel4){
[].forEach.call(document.querySelectorAll('.c-4'), function (el) {
  var slider = tns({
      container: el,
      items: 4,
      controls: true,
      nav: true,
      navPosition: 'bottom',
      gutter: 15,
      preventScrollOnTouch: "force",
      responsive: {
          0: {
              items: 1
          },
          550: {
            items: 2
          },
          768: {
              items: 3
          },
          991: {
            items: 4
          },
          1200: {
            items: 4
          }
      }
    });
  });
}
const carrusel6 = document.getElementsByClassName('c-6');
if(carrusel6){
[].forEach.call(document.querySelectorAll('.c-6'), function (el) {
  var slider = tns({
      container: el,
      items: 6,
      controls: true,
      navPosition: 'bottom',
      gutter: 15,
      preventScrollOnTouch: "force",
      responsive: {
          0: {
              items: 1
          },
          550: {
            items: 2
          },
          768: {
              items: 3
          },
          991: {
            items: 4
          },
          1200: {
            items: 6
          }
      }
    });
  });
}

//Acordeon
const acc = document.getElementsByClassName('accordion');
if(acc){
  for (let i = 0; i < acc.length; i++) {
      let item = acc[i];
      var accordion = new Accordion({
          element: item,
          oneOpen: true
      });
  }
}


if($('.table-responsive').length){
$('.table-responsive').basictable({
  breakpoint: 768
});
}
/*--CALENDAR--*/
$(document).ready(function() {
    
  if($('#calendar').length){
  $('#calendar').fullCalendar({
    header: {
      left: 'prev',
      center: 'title',
      right: 'next'
    },
    titleFormat: 'MMMM YYYY',
    locale: 'es',
    height: 'auto',
    defaultDate: '2019-01-01',
    editable: false,
    views: {
        month: {
        columnFormat:'dddd'
        }
    },
    eventLimit: true, // allow "more" link when too many events
    events: [
      /*
      {
        title: 'All Day Event',
        start: '2019-12-01'
      },
      {
        title: 'Long Event',
        start: '2019-01-07',
        end: '2019-01-10'
      },
      {
        id: 999,
        title: 'Repeating Event',
        start: '2019-01-09T16:00:00'
      },
      {
        id: 999,
        title: 'Repeating Event',
        start: '2019-01-16T16:00:00'
      },
      {
        title: 'Conference',
        start: '2019-01-11',
        end: '2019-01-13'
      },
      {
        title: 'Click for Google',
        url: 'http://google.com/',
        start: '2019-01-28'
      }
      */
    ]
  });    
  }
});
/*--FIN CALENDAR--*/
/*--LAZY--*/
lazyload();

/*--WOW--*/
    wow = new WOW(
      {
        animateClass: 'animated',
        offset:       100,
        mobile: false,
        callback: function(box) {
          if(box.classList.contains("cifras")){
            iniciarCount();
          }
        }
      }
    );
    wow.init();
/*--FIN WOW--*/
