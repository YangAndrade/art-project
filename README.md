# 🖼️ VR Art Gallery — Unity 6 + Meta XR SDK

Uma galeria de arte imersiva em realidade virtual desenvolvida com **Unity 6** e o **Meta XR SDK**, com suporte ao **Meta Quest** e ao **Meta XR Simulator**. O usuário pode explorar a galeria, apontar para quadros e visualizar informações sobre cada obra diretamente na visão do headset.

---

## 🎮 Como Funciona

> Aponte para um quadro → Pressione o **gatilho** → Painel com informações aparece na sua frente → Pressione o **gatilho** novamente para fechar.

---

## 🗂️ Estrutura do Projeto

```
Assets/
├── Scripts/
│   ├── Painting.cs               # Dados de cada obra (título, artista, descrição)
│   ├── PaintingInteractable.cs   # Conecta o quadro ao sistema de UI
│   ├── GalleryUI.cs              # Controla o painel de informações
│   ├── PaintingClick.cs          # Suporte a clique na aba Game (editor)
│   ├── SimulatorInput.cs         # Input via OVRInput para o Meta XR Simulator
│   └── InteractorConnector.cs    # Conecta Ray Interactables aos interactors
│
└── Scenes/
    └── SampleScene.unity         # Cena principal da galeria
```

---

## 🧩 Componentes por Quadro

Cada quadro (`Rectangle22` → `Rectangle33`) dentro de `3d_lounge_01_FBX → pictures` possui:

| Componente                         | Função                          |
| ---------------------------------- | ------------------------------- |
| `Box Collider`                     | Detecta raycast                 |
| `Painting (Script)`                | Armazena dados da obra          |
| `Rigidbody (Kinematic)`            | Necessário para interação XR    |
| `Ray Interactable`                 | Componente de interação Meta XR |
| `Interactable Unity Event Wrapper` | Dispara evento `When Select`    |
| `PaintingInteractable (Script)`    | Chama `GalleryUI.MostrarInfo()` |

---

## 🏗️ Hierarquia da Cena

```
SampleScene
├── [BuildingBlock] Camera Rig
│   └── OVRCameraRig
│       └── TrackingSpace
│           └── CenterEyeAnchor
│               └── Canvas               ← UI segue a cabeça do jogador
│                   └── PainelDescricao
│                       ├── TxtTitulo
│                       ├── TxtArtista
│                       └── TxtDescricao
├── 3d_lounge_01_FBX
│   └── pictures
│       ├── Rectangle22 … Rectangle33    ← Quadros interativos
└── GameManager
    ├── GalleryUI (Script)
    ├── SimulatorInput (Script)
    └── InteractorConnector (Script)
```

---

## ⚙️ Configuração do Canvas (World Space)

| Propriedade    | Valor                 |
| -------------- | --------------------- |
| Render Mode    | World Space           |
| Parent         | CenterEyeAnchor       |
| Local Position | (0, 0, 1.5)           |
| Local Rotation | (0, 0, 0)             |
| Scale          | (0.002, 0.002, 0.002) |

> **Importante:** Após realocar o Canvas dentro do CenterEyeAnchor, sempre verifique se a Scale não foi distorcida pelo Unity. Ajuste manualmente se necessário.

---

## 🕹️ Controles

### No Meta Quest (dispositivo físico)

| Ação                | Controle                    |
| ------------------- | --------------------------- |
| Apontar para quadro | Ray do controle direito     |
| Abrir informações   | Gatilho direito             |
| Fechar painel       | Gatilho direito (novamente) |

### No Meta XR Simulator

| Ação                  | Controle                                  |
| --------------------- | ----------------------------------------- |
| Movimentar câmera     | Mouse                                     |
| Abrir / fechar painel | Tecla `T` (trigger simulado via OVRInput) |

---

## 📜 Scripts — Resumo

### `Painting.cs`

Componente de dados puro. Armazena `titulo`, `artista` e `descricao` de cada obra. Configurado diretamente no Inspector.

### `PaintingInteractable.cs`

Busca o `GalleryUI` na cena e chama `MostrarInfo()` quando o método `Selecionar()` é invocado pelo sistema de interação XR.

### `GalleryUI.cs`

Gerencia a visibilidade do painel. Expõe `MostrarInfo(Painting p)`, `Fechar()` e `PainelAberto()`.

### `SimulatorInput.cs`

Usa `OVRInput.GetDown` para detectar o gatilho no simulador. Se o painel estiver aberto, fecha. Caso contrário, faz raycast a partir da câmera e tenta selecionar um quadro.

### `InteractorConnector.cs`

Encontra automaticamente todos os `RayInteractor` e `RayInteractable` na cena e registra os logs de conexão para diagnóstico.

---

## 🚀 Como Rodar

### No Editor (Meta XR Simulator)

1. Abra a cena `SampleScene`
2. Pressione **Play**
3. O Meta XR Simulator abrirá automaticamente
4. Aponte para um quadro e pressione **T** para interagir

### No Meta Quest

1. Configure o projeto para **Android** em `File → Build Settings`
2. Conecte o headset via cabo USB com modo desenvolvedor ativo
3. Clique em **Build and Run**

---

## 🛠️ Requisitos

- Unity 6 (6000.3.x LTS ou superior)
- Meta XR SDK (via Package Manager)
- Meta XR Simulator (para testes no editor)
- Android Build Support (para build no Quest)
- Dispositivo: Meta Quest 2, 3 ou Pro

---

## 🐛 Problemas Conhecidos e Soluções

**Painel não aparece no Simulator**
→ Verifique se o Canvas está como filho do `CenterEyeAnchor` e com Scale `(0.002, 0.002, 0.002)`.

**Scale do Canvas fica distorcida ao reparentar**
→ Ao arrastar o Canvas para dentro do CenterEyeAnchor, ajuste a Scale manualmente para `(0.002, 0.002, 0.002)`.

**Tecla T não funciona**
→ O projeto usa o **novo Input System**. O `SimulatorInput.cs` usa `OVRInput` que bypassa esse sistema corretamente.

**Simulador piscando**
→ Manter o Canvas em **World Space** como filho do CenterEyeAnchor resolve o conflito de renderização.

---

## 👨‍💻 Desenvolvido por

**Yang Andrade**
Projeto — Galeria de Arte em Realidade Virtual
Unity 6 · Meta XR SDK · Quest
