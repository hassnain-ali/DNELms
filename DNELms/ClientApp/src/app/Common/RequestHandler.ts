import { HttpClient, HttpHeaders, HttpRequest } from "@angular/common/http";
import { FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthorizeService } from "src/api-authorization/authorize.service";

export class RequestHandler {
    IsAuthenticated: boolean
    Token: string = '';
    Header: HttpHeaders = new HttpHeaders();
    BaseUrl: string
    constructor(private http: HttpClient, authService: AuthorizeService,
        router: Router) {
        authService.isAuthenticated().subscribe(s => {
            this.IsAuthenticated = s;
        });
        authService.getAccessToken().subscribe((token: string) => {
            if (!token) {
                router.navigateByUrl('/authentication/login');
            }
            this.Token = token;
            this.Header.set("Authorization", `Bearer ${token}`);
        });
        this.BaseUrl = window.location.origin + "/";
    }
    AuthGet<T>(url: string) {
        return this.http.get<T>(this.BaseUrl + url, { headers: this.Header });
    }
    AnonymousGet<T>(url: string) {
        return this.http.get<T>(this.BaseUrl + url);
    }
    AuthPost<T>(url: string, data: any) {
        return this.http.post<T>(this.BaseUrl + url, data, { headers: this.Header });
    }
    AnonymousPost<T>(url: string, data: any) {

        return this.http.post<T>(this.BaseUrl + url, data);
    }
    Request<T>(req: HttpRequest<T>) {
        return this.http.request(req);
    }
}