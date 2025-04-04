import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { map, Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Produto } from '../models/Produto';
import { PaginatedResult } from '../models/Pagination';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  baseUrl = `${environment.mainUrlAPI}/api/produto`

  constructor( private http: HttpClient) { }

  getAll(page?: number, itemsPerPage?: number): Observable<PaginatedResult<Produto[]>> {
    const paginatedResult: PaginatedResult<Produto[]> = new PaginatedResult<Produto[]>();

    let params = new HttpParams();

    if (page != undefined && itemsPerPage != undefined){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    return this.http.get<Produto[]>(this.baseUrl, {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body ?? [];

        const paginationHeader = response.headers.get('Pagination');
        if (paginationHeader !== null) {
          paginatedResult.pagination = JSON.parse(paginationHeader);
        }
        return paginatedResult;
     }));
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
