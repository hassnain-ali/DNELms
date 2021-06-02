import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { stringify } from "querystring";
import { Observable } from "rxjs";


@Injectable()
export class EntityService {

    private apiPrefix: string;
    private apiEndpoint: string;

    constructor(
        private http: HttpClient) {

      this.apiPrefix = window.location.origin + '/api/';
        this.apiEndpoint = this.apiPrefix + 'CourseCategory';
    }

    fetchLatest(sort: string = '', order: string = '', page: number = 1, perPage: number = 25): Observable<Object> {
        return this.http.get(this.apiEndpoint + '?' + EntityService.createUrlQuery({ sort: { field: sort, order: order }, pagination: { page, perPage } }));
    }

    //should be put in a util
    static createUrlQuery(params: any) {
        if (!params) {
            return "";
        }

        let page: any;
        let perPage: any;
        let field: any;
        let order: any;
        let query: any = {};
        if (params.pagination) {
            page = params.pagination.page;
            perPage = params.pagination.perPage;
            query.range = JSON.stringify([
                page,
                perPage,
            ]);
        }
        if (params.sort) {
            field = params.sort.field;
            order = params.sort.order;
            if (field && order) {
                query.sort = JSON.stringify([field, order]);
            }
            else {
                query.sort = JSON.stringify(['id', 'desc']);
            }
        }
        if (!params.filter) {
            params.filter = {};
        }
        if (Array.isArray(params.ids)) {
            params.filter.id = params.ids;
        }

        if (params.filter) {
            query.filter = JSON.stringify(params.filter)
        }
        return stringify(query);
    }
}
