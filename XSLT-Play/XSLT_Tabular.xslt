<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

  <xsl:template match="Employees">
    <table width="70%">
      <tr align="left">
        <th>EmpId</th>
        <th>Name</th>
        <th>Sex</th>
        <th>Phone</th>
      </tr>

      <xsl:for-each select="Employee">
        <tr>
          <td>
            <xsl:value-of select="EmpId"/>
          </td>
          <td>
            <xsl:value-of select="Name"/>
          </td>
          <td>
            <xsl:value-of select="Sex"/>
          </td>
          <td>
            <xsl:value-of select="Phone"/>
          </td>
          <td>
            <xsl:value-of select="Phone/@Type"/>
          </td>
          <td>
            <input type="text">
            <xsl:attribute name="value">
              <xsl:value-of select="Phone/@Type"/>
            </xsl:attribute>
            </input>
          </td>

        </tr>
        
      </xsl:for-each>
    </table>
  </xsl:template>

  
</xsl:stylesheet>
