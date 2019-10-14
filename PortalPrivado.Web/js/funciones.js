//MENU STICKY
const headSticky = document.getElementById('head-sticky');
const alturaHeader = headSticky .clientHeight;
if (window.innerWidth > 991) {
  setHeader();
  window.addEventListener('scroll', setHeader);
  function setHeader() {
    var scrollTop =  window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
    if(scrollTop > (alturaHeader + 300)) {
      headSticky.classList.add('visible');
    }
    else{
      headSticky.classList.remove('visible');
    }
  }
}


//Boton Menu Mobile
const btnMenu = document.getElementById('btn-menu');
const navHead = document.getElementById('navHead');
const menuSticky = document.getElementsByClassName('sticky-movil');
if(btnMenu){
  btnMenu.addEventListener("click", function(){
    if(btnMenu.classList.contains('open')){
      btnMenu.classList.remove('open');
      btnMenu.classList.add('close');
      navHead.classList.remove('visible');
      menuSticky[0].classList.remove('oculto');
    }else{
      btnMenu.classList.remove('close');
      btnMenu.classList.add('open');
      navHead.classList.add('visible');
      menuSticky[0].classList.add('oculto');
    }
  });
}
//Ver Fonos
const verFono = document.getElementById('verFono');
const fonos = document.getElementById('fonos');
const cerrarFonos = document.getElementById('cerrar-fonos');

const lupa = document.getElementById('lupa');
const lupa2 = document.getElementById('lupa2');
const buscador = document.getElementById('buscador');
const buscador2 = document.getElementById('buscador2');

if(verFono){
  verFono.addEventListener("click", function(e){
    e.preventDefault();
    verFono.classList.add('oculto');
    fonos.classList.add('visible');
    buscador.classList.remove('visible');
    buscador2.classList.remove('visible');
    lupa.classList.remove('oculto');
    lupa2.classList.remove('oculto');
  });
  cerrarFonos.addEventListener("click", function(e){
    e.preventDefault();
    verFono.classList.remove('oculto');
    fonos.classList.remove('visible');
  });
}
//Ver Buscador

if(lupa){
  lupa.addEventListener("click", function(e){
    e.preventDefault();
    lupa.classList.add('oculto');
    buscador.classList.add('visible');

    verFono.classList.remove('oculto');
    fonos.classList.remove('visible');
  });
}
if(lupa2){
  lupa2.addEventListener("click", function(e){
    e.preventDefault();
    lupa2.classList.add('oculto');
    buscador2.classList.add('visible');

    verFono.classList.remove('oculto');
    fonos.classList.remove('visible');
  });
}

//Cerrar alerta
const cerrarAlerta = document.getElementById('cerrar-alerta');
const alerta1 = document.getElementById('alerta-1');
if(alerta1){
  cerrarAlerta.addEventListener("click", function(e){
    e.preventDefault();
    alerta1.classList.add('oculto');
  });
}

const btnBuscarMovil = document.querySelector('.buscar-movil');
const buscadorMovil = document.querySelector('.buscador-movil');
const btnLoginMovil = document.querySelector('.login-movil');
const boxLoginMovil = document.querySelector('.box-login-movil');
const btnRescateMovil = document.querySelector('.rescate-movil');
const boxRescateMovil = document.querySelector('.box-rescate-movil');

//Buscador Movil
var bm = 0;
var br = 0;
var bl = 0;
if(btnBuscarMovil){
  btnBuscarMovil.addEventListener("click", function(e){
    e.preventDefault();
    if(bm == 0){
      buscadorMovil.classList.add('visible');

      boxRescateMovil.classList.remove('visible');
      boxLoginMovil.classList.remove('visible');

      btnBuscarMovil.classList.add('activo');
      btnRescateMovil.classList.remove('activo');
      btnLoginMovil.classList.remove('activo');
      bm = 1;
      br = 0;
      brl = 0;
    }
    else {
      buscadorMovil.classList.remove('visible');
      this.classList.remove('activo');
      bm = 0;    
    }
  });
}
//Rescate Movil
if(btnRescateMovil){
  btnRescateMovil.addEventListener("click", function(e){
    e.preventDefault();
    if(br == 0){
      boxRescateMovil.classList.add('visible');

      boxLoginMovil.classList.remove('visible');
      buscadorMovil.classList.remove('visible');

      btnBuscarMovil.classList.remove('activo');
      btnRescateMovil.classList.add('activo');
      btnLoginMovil.classList.remove('activo');
      br = 1;
      bm = 0;
      bl = 0;
    }
    else {
      boxRescateMovil.classList.remove('visible');
      this.classList.remove('activo');
      br = 0;    
    }
  });
}
//Login Movil
if(btnLoginMovil){
  btnLoginMovil.addEventListener("click", function(e){
    e.preventDefault();
    if(bl == 0){
      boxLoginMovil.classList.add('visible');

      buscadorMovil.classList.remove('visible');
      boxRescateMovil.classList.remove('visible');

      btnBuscarMovil.classList.remove('activo');
      btnRescateMovil.classList.remove('activo');
      btnLoginMovil.classList.add('activo');
      bl = 1;
      br = 0;
      bm = 0;
    }
    else {
      boxLoginMovil.classList.remove('visible');
      this.classList.remove('activo');
      bl = 0;    
    }
  });
}

const itemsMenu = document.querySelectorAll('#navHead ul li i');
for (const itemM of itemsMenu) {
  itemM.addEventListener('click', function(event) {
    if(itemM.parentElement.querySelectorAll(".submenu").length > 0){
      const sm = itemM.parentElement.querySelectorAll(".submenu")
      sm[0].classList.toggle('visible');
    }
    else {
      const todosSub = document.querySelectorAll('#navHead .submenu');
      for (const ts of todosSub) {
        ts.classList.remove('visible');
      }
    }
  })
}

const btnSer = document.querySelector('.m-servicios');
const menuSer = document.querySelector('.menu-servicios');
const icSer = document.querySelector('.m-servicios i');

var bs = 0;
if(btnSer){
  btnSer.addEventListener("click", function(e){
    e.preventDefault();
    if(bs == 0) {
      menuSer.classList.add('visible');
      icSer.classList.add('fa-times');
      icSer.classList.remove('fa-chevron-up');
      bs = 1;
    } else {
      menuSer.classList.remove('visible');
      icSer.classList.remove('fa-times');
      icSer.classList.add('fa-chevron-up');
      bs = 0;  
    }
  });
}

const cerrarPopAlerta = document.querySelector('.cerrar-alerta-pop');
const cerrarPopAlerta2 = document.querySelector('.w-alerta .btn');
const alertaPop = document.getElementById('alerta-pop');
if(cerrarPopAlerta){
  cerrarPopAlerta.addEventListener("click", function(e){
    e.preventDefault();
    alertaPop.classList.add('oculto');
  });
  cerrarPopAlerta2.addEventListener("click", function(e){
    e.preventDefault();
    alertaPop.classList.add('oculto');
  });
}

const verEsp = document.querySelectorAll('.ver-especialidad');
const ocultarEsp = document.querySelectorAll('.ocultar-especialidad');

if(verEsp){
  for (const item of verEsp) {
    item.addEventListener("click", function(e){
      e.preventDefault();
      this.parentElement.classList.add('visible');
    });
  }
}
if(ocultarEsp){
  for (const item of ocultarEsp) {
    item.addEventListener("click", function(e){
      e.preventDefault();
      this.parentElement.classList.remove('visible');
    });
  }
}

//Cerrar Como LLegar
const cerrarBox = document.getElementsByClassName('cerrar-box-llegar');
const verBox = document.getElementsByClassName('ver-box-llegar');
const Box = document.getElementsByClassName('box-como-llegar');
if(cerrarBox[0]){
  cerrarBox[0].addEventListener("click", function(e){
    e.preventDefault();
    verBox[0].classList.add('visible');
    Box[0].classList.add('oculto');
  });
  verBox[0].addEventListener("click", function(e){
    e.preventDefault();
    verBox[0].classList.remove('visible');
    Box[0].classList.remove('oculto');
  });
}

//TABS
const itemTab = document.querySelectorAll('.menu-tabs a');
const itemsPanel = document.querySelectorAll('.item-panel');
for (const item of itemTab) {
  item.addEventListener('click', function(event) {
    for (const it of itemTab) {
      it.classList.remove('activo');
    }
    this.classList.add('activo');
    event.preventDefault();
    var idTab = item.dataset.rel;
    for (const ip of itemsPanel) {
      ip.classList.remove('activo');
    }
    const panel = document.getElementById('panel-' + idTab);
    panel.classList.add('activo');
  })
}

//Ver Especialidades
const verLista = document.getElementById('ver-lista');
const verGrid = document.getElementById('ver-grid');
const gridEsp = document.getElementsByClassName("grid-esp");
if(verLista){
  verLista.addEventListener("click", function(e){
    e.preventDefault();
    verGrid.classList.remove('activo');
    this.classList.add('activo');
    gridEsp[0].classList.add('lista-esp');
  });
}
if(verGrid){
  verGrid.addEventListener("click", function(e){
    e.preventDefault();
    verLista.classList.remove('activo');
    this.classList.add('activo');
    gridEsp[0].classList.remove('lista-esp');
  });
}
//Ver Noticias
const verListaNot = document.getElementById('ver-lista-not');
const verGridNot = document.getElementById('ver-grid-not');
const gridNot = document.getElementsByClassName("grid-not");
if(verListaNot){
  verListaNot.addEventListener("click", function(e){
    e.preventDefault();
    verGridNot.classList.remove('activo');
    this.classList.add('activo');
    gridNot[0].classList.add('lista-not');
  });
}
if(verGridNot){
  verGridNot.addEventListener("click", function(e){
    e.preventDefault();
    verListaNot.classList.remove('activo');
    this.classList.add('activo');
    gridNot[0].classList.remove('lista-not');
  });
}

const indices = document.querySelectorAll('.indice-glosario a');

if(indices){
  for (const indice of indices) {
    indice.addEventListener("click", function(e){
      e.preventDefault();
      var letra = indice.dataset.rel;
      console.log(letra);
      const glo = document.querySelectorAll('.res-glosario');
      for (const g of glo) {
        g.classList.remove('activo');
      }
      var ac = document.getElementById('glosario-'+letra);
      ac.classList.add('activo');
    });
  }
}


const btnContrata = document.querySelectorAll('.ver-pop-contrata');
const popContrata = document.getElementsByClassName("pop-contrata");
const cerrarPop = document.querySelectorAll('.cerrar-pop');
const popUp = document.querySelectorAll('.pop-up');

if(btnContrata){
  for (const contrata of btnContrata) {
    contrata.addEventListener("click", function(e){
      e.preventDefault();
      popContrata[0].classList.add('visible');
    });
  }
}

const btnRenueva = document.querySelectorAll('.ver-pop-renueva');
const popRenueva = document.getElementsByClassName("pop-renueva");

if(btnRenueva){
  for (const renueva of btnRenueva) {
    renueva.addEventListener("click", function(e){
      e.preventDefault();
      popRenueva[0].classList.add('visible');
    });
  }
}

if(cerrarPop){
  for (const cerrar of cerrarPop) {
    cerrar.addEventListener("click", function(e){
      e.preventDefault();
      for (const pop of popUp) {
        pop.classList.remove('visible');
      }
    });
  }
}

const boxesNot = document.querySelectorAll('.noticias-home .box-noticia:not(.noticia-destacada) .texto-noticia');

var h = 0;
if(boxesNot){
  for (const not of boxesNot) {
    var ht = not.clientHeight;
    if(ht > h){
        h = ht;
    }         
  }
  console.log(h);
  for (const not1 of boxesNot) {
    not1.style.height = h+'px';
  }
}

const boxPrograma = document.querySelectorAll('.body-detalle .box-programa h4');
const ulPrograma = document.querySelectorAll('.body-detalle .box-programa ul');

if(boxPrograma){
  for (const prog of boxPrograma) {
    prog.addEventListener("click", function(e){
      e.preventDefault();
      for (const ulP of ulPrograma) {
        ulP.classList.remove('visible'); 
      }
      const p = prog.parentElement.getElementsByTagName('ul');   
      p[0].classList.add('visible');    
    });
  }
}


function scrollToSmoothly(pos, time){
/*Time is only applicable for scrolling upwards*/
/*Code written by hev1*/
/*pos is the y-position to scroll to (in pixels)*/
time = 10;
     if(isNaN(pos)){
      throw "Position must be a number";
     }
     if(pos<0){
     throw "Position can not be negative";
     }
    var currentPos = window.scrollY||window.screenTop;
    if(currentPos<pos){
    if(time){
    	var x;
      var i = currentPos;
      x = setInterval(function(){
         window.scrollTo(0, i);
         i += 10;
         if(i>=pos){
          clearInterval(x);
         }
     }, time);
    } else {
    var t = 10;
       for(let i = currentPos; i <= pos; i+=10){
       t+=10;
        setTimeout(function(){
      	window.scrollTo(0, i);
        }, t/2);
      }
      }
    } else {
    time = time || 2;
       var i = currentPos;
       var x;
      x = setInterval(function(){
         window.scrollTo(0, i);
         i -= 10;
         if(i<=pos){
          clearInterval(x);
         }
     }, time);
      }
}
function scrollToDiv(){
  var elem = document.getElementById('noticias');
  scrollToSmoothly(elem.offsetTop - 50);
}
function GoTo(id){
  var elem = document.getElementById(id);
  scrollToSmoothly(elem.offsetTop);
}

//SubMenu interior
var selectEl = document.querySelector('.m-int-mobile select');

if(selectEl){
  selectEl.onchange = function(){
    var goto = this.value;
    window.location = goto;
  
  };
}
