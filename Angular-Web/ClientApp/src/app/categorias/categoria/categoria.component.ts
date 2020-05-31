import { Component , OnInit } from '@angular/core'
import { CategoriaService } from '../servicio-model/categoria.service';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-categoria',
    templateUrl: './categoria.component.html'
})

export class CategoriaComponent implements OnInit{
    constructor(private service: CategoriaService) {

    }

    ngOnInit() {
        this.resetFrom();
    }

    resetFrom(form?: NgForm) {
        if(form!=null)
        form.resetForm();
        this.service.formData = {
            id: null,
            descripcion: '',
            empresaId: 0,
            eliminado: false
        }
    }
}
