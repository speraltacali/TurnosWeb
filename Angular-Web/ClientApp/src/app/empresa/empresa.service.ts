import { Injectable , Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EmpresaDto } from './empresa.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EmpresaServicio {
    constructor(private http: HttpClient, @Inject("BASE_URL") private urlBase: string ) {
    }

    empresa: EmpresaDto;

    public get(): Observable<EmpresaDto[]> {
        return this.http.get<EmpresaDto[]>(this.urlBase + 'api/Empresa');
    }

    public post(empresa: EmpresaDto): Observable<EmpresaDto> {
        return this.http.post<EmpresaDto>(this.urlBase + 'api/Empresa', empresa);
    }
}
