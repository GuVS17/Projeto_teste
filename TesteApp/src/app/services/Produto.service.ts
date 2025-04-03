import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Produto } from '../models/Produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  baseUrl = `${environment.mainUrlAPI}/api/produto`

  constructor( private http: HttpClient) { }

  getAll(): Observable<Produto[]> {
    return this.http.get<Produto[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Produto> {
    return this.http.get<Produto>(`${this.baseUrl}/${id}`);
  }

  post(produto : Produto): Observable<Produto> {
    return this.http.post<Produto>(`${this.baseUrl}`, produto);
  }

  put(produto: Produto): Observable<Produto> {
    return this.http.put<Produto>(`${this.baseUrl}/${produto.id}`, produto)
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
