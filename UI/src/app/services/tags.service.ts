import { Injectable } from '@angular/core';
import { Headers, RequestOptions, Http } from '@angular/http';

import '../shared/rxjs-operators';
import { Observable } from 'rxjs/observable';

import { HttpService } from './http.service';
import { Tag } from '../models/tag';

@Injectable()
export class TagsService {
  private headers = new Headers({ 'Content-Type': 'application/json' });
  private apiUrl = '/api/tags';

  constructor(private http: Http, private httpService: HttpService) { }

  getAll(): Observable<Tag[]> {
    return this.http.get(this.apiUrl)
      .map(res => res.json() as Tag[])
      .catch(this.httpService.handleError);
  }

  getById(id: number): Observable<Tag> {
    let apiUrlWithId = this.apiUrl + '/' + id;
    return this.http.get(apiUrlWithId)
      .map(res => res.json() as Tag)
      .catch(this.httpService.handleError);
  }

  create(tag: Tag): Observable<Tag> {
    let options = new RequestOptions({ headers: this.headers });
    return this.http.post(this.apiUrl, JSON.stringify(tag), options)
      .map(res => res.json() as Tag)
      .catch(this.httpService.handleError);
  }

  delete(id: number): Observable<Tag> {
    let apiUrlWithId = this.apiUrl + '/' + id;
    let options = new RequestOptions({ headers: this.headers });
    return this.http.delete(apiUrlWithId, options)
      .catch(this.httpService.handleError);
  }
}
