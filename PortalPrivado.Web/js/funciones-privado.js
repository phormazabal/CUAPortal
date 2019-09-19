//Editar
const editForm = document.querySelectorAll('span.editar-f');
const editables = document.querySelectorAll('input.editable');
const formPerfil = document.getElementById('form-perfil');
const cancelarEdit = document.getElementById('cancelar-editar');
const guardarEdit = document.getElementById('guardar-editar');

if(editForm){
  for (const edit of editForm) {
    edit.addEventListener("click", function(e){
      formPerfil.classList.add('modo-editar')
      for (const inputEditable of editables) {
        inputEditable.removeAttribute('readonly')
      }
    });
  }
}
if(cancelarEdit){
  cancelarEdit.addEventListener("click", function(e){
    e.preventDefault();
    formPerfil.classList.remove('modo-editar')
    for (const inputEditable of editables) {
      inputEditable.addAttribute('readonly')
    }
  });   
}
if(guardarEdit){
  guardarEdit.addEventListener("click", function(e){
    e.preventDefault();
    formPerfil.classList.remove('modo-editar')
    for (const inputEditable of editables) {
      inputEditable.addAttribute('readonly')
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