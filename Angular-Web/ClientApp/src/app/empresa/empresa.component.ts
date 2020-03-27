import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'


@Component({
    selector: "empresa-app",
    templateUrl: "./empresa.component.html"
})

export class EmpresaComponent {

    public empresas: Empresa[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Empresa[]>(baseUrl + 'api/Empresa/ObtenerTodo').subscribe(result => {
            this.empresas = result;
        }, error => console.error(error));
    }
}

interface Empresa {
    Id: number
    RazonSocial: string
    Descripcion: string
    Cuil: string
    Eliminado: boolean
}

