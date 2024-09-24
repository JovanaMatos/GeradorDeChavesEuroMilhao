function validarRepetidos() {

    const mensagemErroN = document.querySelector("#mensagemErroN"); // span msg erro
    const mensagemErroE = document.querySelector("#mensagemErroE");

    const numb1 = document.querySelector("#numb1").valueAsNumber; //pegando cada input
    const numb2 = document.querySelector("#numb2").valueAsNumber;
    const numb3 = document.querySelector("#numb3").valueAsNumber;
    const numb4 = document.querySelector("#numb4").valueAsNumber;
    const numb5 = document.querySelector("#numb5").valueAsNumber;

    const star1 = document.querySelector("#star1").valueAsNumber;
    const star2 = document.querySelector("#star2").valueAsNumber;


    const numbers = [numb1, numb2, numb3, numb4, numb5].filter(value => !isNaN(value)); //add apenas numeros 

    const stars = [star1, star2].filter(value => !isNaN(value));

    mensagemErroN.textContent = ""; //limpando msg erro
    mensagemErroE.textContent = "";

    let erroN = "";// para enviar erros
    let erroE = "";
    let contErro = 0;

    if (new Set(numbers).size !== numbers.length) {
        contErro++;
        erroN = "Os números não podem ser iguais.";
    }


    if (new Set(stars).size !== stars.length) {

        contErro++;
        erroE = "As estrelas não podem ser iguais.";
    }


    if (contErro != 0) {

        if (erroN != "") {
            mensagemErroN.textContent = erroN;// atribuindo msg erro
        }
        if (erroE != "") {
            mensagemErroE.textContent = erroE;
        }
        return false;//  não deixa validar o form
    }
    else {
        mensagemErroN.textContent = ""; // limpA Msg de erro antes de validar o form
        mensagemErroE.textContent = ""; 
        return true;
    }

    function LimparCampos() {

        document.querySelector("#numb1").value(''); //limpando inputs
        document.querySelector("#numb2").value('');
        document.querySelector("#numb3").value('');
        document.querySelector("#numb4").value('');
        document.querySelector("#numb5").value('');
                                       
        document.querySelector("#star1").value('');
        document.querySelector("#star2").value('');


    }

  


    
}
