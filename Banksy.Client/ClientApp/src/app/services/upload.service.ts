import { Injectable, Inject } from "@angular/core";
import { API_BASE_URL } from "../injection-tokens/api-base-url-token";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class UploadService {
  private baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject(API_BASE_URL) private apiServerUrl: string
  ) {
    this.baseUrl = `${apiServerUrl}/api/import`;
  }

  uploadFile(file: File) {
    const formData = new FormData();
    formData.append(file.name, file);
    return this.http.post(`${this.baseUrl}`, formData, {
      responseType: "text"
    });
  }
}
