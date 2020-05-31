import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmpresaDto } from './empresa.model';
import { EmpresaServicio } from './empresa.service';

@Component({
    selector: 'app-empresa',
    templateUrl: './empresa.component.html'
})

export class EmpresaComponent implements OnInit {

    public empresas: EmpresaDto[];


    constructor(private empresaServicio: EmpresaServicio) {

    }

    ngOnInit() {
        this.cargarDatos();
    }

    cargarDatos() {
        this.empresaServicio.get()
            .subscribe(result => this.empresas = result,
                error => console.error(error));
    }

    //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //    http.get<EmpresaDto[]>(baseUrl + 'api/Empresa').subscribe(result => {
    //        this.empresas = result;
    //    }, error => console.error(error));
    //}
}

