export const ComponentUtil = {
  defaultProps(name: string){
    return {
      standalone: true,
      selector: `app-${name}`,
      templateUrl: `./${name}.component.html`,
      styleUrl: `./${name}.component.scss`,
    }
  }
}