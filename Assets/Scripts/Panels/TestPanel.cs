﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestPanel : InteractionPanel {
    private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public Text label;

    public override PanelActionSetBase createViableActionSet(HashSet<string> existingLabels) {
        char randomChar = ALPHABET.chooseRandom(c => !existingLabels.Contains(c.ToString()));
        return new SinglePanelActionSet(randomChar.ToString(), "Press " + randomChar);
    }

    public override void setActionSet(PanelActionSetBase actionSet) {
        base.setActionSet(actionSet);
        label.text = actionSet.panelLabel;
    }

    public void OnButtonPress() {
        new PanelActionMessage(_actionSet.setId).sendToServer();
    }
}
