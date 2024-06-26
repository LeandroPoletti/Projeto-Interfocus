const URL_API = "http://127.0.0.1:5189";

export  function listarClientes(pagina, pesquisa){
    
    let query = "?page=" + pagina
    let response =  pesquisa ?  fetch(URL_API+"/api/cliente"+query+"&q="+pesquisa) : fetch(URL_API+"/api/cliente"+query) 

    return response
}

export function getCliente(id){
    let response = fetch(URL_API+"/api/cliente/"+id)
    return response
}


export function postCliente(cliente) {
    let request = {
        method: cliente.id ? "PUT" : "POST",
        headers: {
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(cliente)
    }

    let response = fetch(URL_API+"/api/cliente", request)

    return response
}


export function idadeAtual(nascimento){
    var today = new Date();
    var birthDate = new Date(nascimento);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m == 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}
