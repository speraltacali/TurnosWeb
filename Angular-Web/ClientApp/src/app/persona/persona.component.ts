import { Component, Inject, Input } from '@angular/core'
import { HttpClient } from '@angular/common/http'


@Component({
    selector: 'persona-app',
    templateUrl: './persona.component.html'
})

export class PersonaComponent {
    public personas: Persona[];
      
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Persona[]>(baseUrl + 'api/Persona').subscribe(result => {
            this.personas = result;
        }, error => console.error(error));
    }
}

interface Persona {
    Id: number,
    Nombre: string,
    Apelliod: string
}


