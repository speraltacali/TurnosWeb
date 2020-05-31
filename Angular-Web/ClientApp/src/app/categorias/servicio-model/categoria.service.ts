import { Injectable } from '@angular/core'
import { Categoria } from './categoria.model'

@Injectable({
    providedIn: 'root'
})

export class CategoriaService {

    formData: Categoria;

    constructor() {

    }
}
