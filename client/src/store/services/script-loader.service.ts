import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ScriptLoaderService {
  private loadedScripts: Record<string, boolean> = {};

  loadScript(src: string): Promise<void> {
    return new Promise((resolve, reject) => {
      // Prevent reloading the same script
      if (this.loadedScripts[src]) {
        resolve();
        return;
      }

      const script = document.createElement('script');
      script.src = src;
      script.async = true;
      script.defer = true;

      script.onload = () => {
        this.loadedScripts[src] = true;
        resolve();
      };

      script.onerror = (err) => reject(err);

      document.body.appendChild(script);
    });
  }
}
