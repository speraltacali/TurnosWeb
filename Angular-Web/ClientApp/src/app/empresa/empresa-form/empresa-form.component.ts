import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmpresaServicio } from '../empresa.service';
import { EmpresaDto } from '../empresa.model';
import { Router } from '@angular/router';

@Component({
    selector: 'app-empresa-form',
    templateUrl: './empresa-form.component.html',
})
export class EmpresaFormComponent implements OnInit {
    constructor(private fb: FormBuilder, private empresaServicio: EmpresaServicio
        , private router: Router) {
    }

    formGroup: FormGroup;

    ngOnInit() {
        this.formGroup = this.fb.group({
            razonSocial: '',
            descripcion: '',
            cuil: ''
        });
    }
        
    guardar() {
        let empresa: EmpresaDto = Object.assign({}, this.formGroup.value);
        console.table(empresa);

        this.empresaServicio.post(empresa)
            .subscribe(empresa => this.save());
    }

    resetForm() {

    }

    save() {
        this.router.navigate(['https://localhost:44359/api/Empresa'])
    }
}
