//Editar
const editForm = document.querySelectorAll('span.editar-f');
const editables = document.querySelectorAll('input.editable');
const formGroup = document.querySelectorAll('.f-edit');
const formPerfil = document.getElementById('form-perfil');
const cancelarEdit = document.getElementById('cancelar-editar');
const guardarEdit = document.getElementById('guardar-editar');
const modificarEdit = document.getElementById('modificar-editar');
const verPass = document.getElementById('ver-pass');
const inputPass = document.getElementById('input-pass');

if(editForm){
  for (const edit of editForm) {
    edit.addEventListener("click", function(e){
      edit.parentElement.parentElement.classList.add('editable');
      formPerfil.classList.add('modo-editar')
      edit.parentElement.parentElement.querySelector('input').removeAttribute('readonly');
    });
  }
}
if(cancelarEdit){
  cancelarEdit.addEventListener("click", function(e){
    e.preventDefault();
    formPerfil.classList.remove('modo-editar')
    for (const fg of formGroup) {
      fg.classList.remove('editable');
    }
    for (const inputEditable of editables) {
      inputEditable.setAttribute('readonly','')
    }
  });   
}
if(guardarEdit){
  guardarEdit.addEventListener("click", function(e){
    e.preventDefault();
    formPerfil.classList.remove('modo-editar')
    for (const fg of formGroup) {
      fg.classList.remove('editable');
    }
    for (const inputEditable of editables) {
      inputEditable.setAttribute('readonly','')
    }
  });   
}
if(modificarEdit){
  modificarEdit.addEventListener("click", function(e){
    e.preventDefault();
    formPerfil.classList.add('modo-editar')
    for (const fg of formGroup) {
      fg.classList.add('editable');
    }
    for (const inputEditable of editables) {
      inputEditable.removeAttribute('readonly')
    }
  });   
}
if(verPass){
  let c = 0;
  verPass.addEventListener("click", function(e){
    e.preventDefault();
    if(c == 0){
      inputPass.type = 'text'
      c = 1
    }
    else {
      inputPass.type = 'password'
      c = 0
    }
  });   
}


const btnDesvincular = document.querySelectorAll('.btn-desvincular');
const btnDesvincularExito = document.querySelectorAll('.open-desvincular-exito');
const popDesvincular = document.getElementsByClassName('pop-desvinculacion');
const popDesvincularExito = document.getElementsByClassName('pop-desvinculacion-exito');
const popUpPrivado = document.getElementsByClassName('popup');
const cerrarPopPrivado = document.getElementsByClassName('close-pop');
const btnCompartir = document.getElementById('compartir-examen');
const popCompartir = document.getElementsByClassName("pop-compartir-examen");
const btnReservarHora = document.querySelectorAll('.res-hora');
const popConfirmarHora = document.getElementsByClassName('pop-confirmar-hora');
const btnAnularHora = document.querySelectorAll('.anular-hora');
const popAnularHora = document.getElementsByClassName('pop-anular-hora');

if(btnCompartir){
  btnCompartir.addEventListener("click", function(e){
    e.preventDefault();
    popCompartir[0].classList.add('visible');
  });
}
if(btnDesvincular){
  for (const desv of btnDesvincular) {
    desv.addEventListener("click", function(e){
      e.preventDefault();
      popDesvincular[0].classList.add('visible');    
    });
  }
}
if(btnReservarHora){
  for (const desv of btnReservarHora) {
    desv.addEventListener("click", function(e){
      e.preventDefault();
      popConfirmarHora[0].classList.add('visible');    
    });
  }
}
if(btnAnularHora){
  for (const desv of btnAnularHora) {
    desv.addEventListener("click", function(e){
      e.preventDefault();
      popAnularHora[0].classList.add('visible');    
    });
  }
}
if(cerrarPopPrivado) {
  for (const cerrarP of cerrarPopPrivado) {
    cerrarP.addEventListener("click", function(e){
      e.preventDefault();
      for (const pop of popUpPrivado) {
        pop.classList.remove('visible');    
      }  
    });
  }
}
if(btnDesvincularExito){
  for (const desvExito of btnDesvincularExito) {
    desvExito.addEventListener("click", function(e){
      e.preventDefault();
      for (const pop of popUpPrivado) {
        pop.classList.remove('visible');    
      }  
      popDesvincularExito[0].classList.add('visible');    
    });
  }
}

$(document).ready(function(){

  $('.menu-usuario').on('click','.m-dropdown.close',function(){
    $(this).removeClass('close');
    $(this).addClass('open');
  });
  $('.menu-usuario').on('click','.m-dropdown.open',function(){
    $(this).addClass('close');
    $(this).removeClass('open');
  });
  $(".box-login").mouseleave(function() {
    $('.m-dropdown').removeClass('open');
    $('.m-dropdown').addClass('close');
  });

  $('.panel-usuario').on('click','.m-dropdown.close',function(){
    $(this).removeClass('close');
    $(this).addClass('open');
  });
  $('.panel-usuario').on('click','.m-dropdown.open',function(){
    $(this).addClass('close');
    $(this).removeClass('open');
  });
});


$(document).ready(function() {
  if($('.chosen-select').length) {
    $('.chosen-select').select2({
        "language": {
            "noResults": function(){
                return "No hay resultados";
            }
        }
    });
  }
});

/*--CAMBIO MENU LATERAL MOBILE--*/
$(document).ready(function(){
  $('.btn-panel-usuario').click(function(){
    $(this).toggleClass('open');
    $('.home-priv .panel-usuario ul').toggleClass('visible');
  });
});
/*--FIN CAMBIO MENU LATERAL MOBILE--*/