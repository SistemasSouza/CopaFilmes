(this.webpackJsonpfrontend=this.webpackJsonpfrontend||[]).push([[0],{33:function(e,t,a){e.exports=a(65)},38:function(e,t,a){},57:function(e,t,a){},58:function(e,t,a){},59:function(e,t,a){},65:function(e,t,a){"use strict";a.r(t);var n=a(0),c=a.n(n),r=a(26),l=a.n(r),s=(a(38),a(29)),o=a(6),i=a(32),u=a(13),m=a.n(u),p=a(27),f=a(8),d=a(28),E=a.n(d).a.create({baseURL:"https://app-copa-filmes.herokuapp.com/api"});a(57),a(58);function v(e){var t=e.title,a=e.phase;return(c.a.createElement("div",{className:"container-topo"},c.a.createElement("p",{className:"title"},"CAMPEONATO  DE FILMES"),c.a.createElement("h3",null,t),c.a.createElement("p",null,a)))}function h(e){var t=e.history,a=Object(n.useState)(0),r=Object(f.a)(a,2),l=r[0],s=r[1],o=Object(n.useState)([]),u=Object(f.a)(o,2),d=u[0],h=u[1],b=Object(n.useState)([]),N=Object(f.a)(b,2),O=N[0],g=N[1];function j(e){var t=e.target.checked;s(t?l+1:l-1),function(e,t){var a=Object(i.a)(O);if(t){var n=d.find((function(t){return t.id===e}));a.push(n)}else O.filter((function(t){return t.id===e&&a.splice(a.indexOf(e),1),0}));g(a)}(e.target.value,t)}return Object(n.useEffect)((function(){function e(){return(e=Object(p.a)(m.a.mark((function e(){var t;return m.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,E.get("/movies/obter-todos-filmes");case 2:t=e.sent,h(t.data);case 4:case"end":return e.stop()}}),e)})))).apply(this,arguments)}sessionStorage.removeItem("result"),function(){e.apply(this,arguments)}()}),[]),c.a.createElement(c.a.Fragment,null,c.a.createElement(v,{title:"Fase de Sele\xe7\xe3o",phase:"Selecione 8 filmes que voc\xea deseja que entrem na competi\xe7\xe3o\n    e depois pressione o bot\xe3o Gerar Meu Campeonato para prosseguir "}),c.a.createElement("div",{className:"container"},c.a.createElement("div",{className:"actions"},c.a.createElement("div",{className:"count"},"Selecionados ",c.a.createElement("br",null)," ",l," de 8 filmes"),c.a.createElement("button",{className:8===l?"":"btn-disabled",onClick:function(){E.post("movies/resultado-final",O).then((function(e){g([]),sessionStorage.setItem("result",JSON.stringify(e.data)),t.push("resultado")})).catch((function(e){g([]),alert("Houve um erro ao gerar o campeonato")}))}},"Gerar meu campeonato")),c.a.createElement("div",{className:"container-movies"},c.a.createElement("ul",{className:"list-movies"},(d||[]).map((function(e){return c.a.createElement("li",{className:"movies-item",key:e.id},c.a.createElement("label",{className:"container-check"},c.a.createElement("input",{type:"checkbox",value:e.id,onChange:function(e){return j(e)}}),c.a.createElement("span",{className:"checkmark"})),c.a.createElement("div",{className:"info-movie"},c.a.createElement("p",null,e.titulo),c.a.createElement("span",null,e.ano)))}))))))}a(59);function b(){var e=Object(n.useState)([]),t=Object(f.a)(e,2),a=t[0],r=t[1];return Object(n.useEffect)((function(){var e=JSON.parse(sessionStorage.getItem("result"));r(e)}),[]),c.a.createElement(c.a.Fragment,null,c.a.createElement(v,{title:"Resultado Final",phase:"Veja o resultado final do campeonato de filmes de forma simples e r\xe1pida"}),c.a.createElement("div",{className:"container"},c.a.createElement("ul",{className:"result-list-movies"},(a||[]).map((function(e,t){return c.a.createElement("li",{className:"result-movies-item",key:e.id},c.a.createElement("span",null,t+1,"\xb0"),"  ",e.titulo)})))))}var N=function(){return c.a.createElement(s.a,null,c.a.createElement(o.c,null,c.a.createElement(o.a,{exact:!0,path:"/",component:h}),c.a.createElement(o.a,{exact:!0,path:"/resultado",component:b})))};var O=function(){return c.a.createElement(c.a.Fragment,null,c.a.createElement(N,null))};l.a.render(c.a.createElement(c.a.StrictMode,null,c.a.createElement(O,null)),document.getElementById("root"))}},[[33,1,2]]]);
//# sourceMappingURL=main.a8c34b47.chunk.js.map